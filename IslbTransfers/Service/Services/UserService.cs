using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL.DbRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using Newtonsoft.Json;

namespace Service.Services
{
    public interface IUserService
    {
        UserClientData Authenticate(User user);
        UserClientData Register(User user);
        User CheckForUserIdentity(string email, string password);
        User GetByEmail(string email);
        Task<UserFacebookCredentials> GetUserDataViaFacebook(string token);
        Task<UserGoogleCredentials> GetUserDataViaGoogle(string token);
        string HashPassword(string password);
        bool CheckHash(string typedPassword, string storedPassword);
        void Add(User user);
        void AddSession(int userId, string token);
        void Update(User user);
        void AddExternalLogin(UserExternalLogin login);
        UserExternalLogin GetExternalLogin(string id, string name);
        void DeleteExpiredUserSessions();
        void InValidateUserSession(int userId, string token);
        bool ReValidateUserSession(string token, string email);
        void AddIdentity(UserIdentityKyc userIdentity);
        string GenerateSocketToken(int userId);
    }
    public class UserService : IUserService
    {
        private readonly IDbRepository<User> _userRepository;
        private readonly IDbRepository<UserSession> _sessionRepository;
        private readonly IDbRepository<UserExternalLogin> _externalLoginRepository;
        private readonly OAuthSettings _oauthOptions;

        private readonly int _defaultUserSessionTimeOut = 7;
        private readonly string _secureCode = "some_secure_code_#refJHJFHcnn212"; //TODO: The more protected salt needed to be implemented in secure reasons

        public UserService(IDbRepository<User> userRepository, IOptions<OAuthSettings> oauthOptions, IDbRepository<UserSession> sessionRepository, IDbRepository<UserExternalLogin> externalLoginRepository)
        {
            this._userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _externalLoginRepository = externalLoginRepository;
            _oauthOptions = oauthOptions.Value;
        }

        // Login user and get his unique session token
        public UserClientData Authenticate(User user)
        {
            // If login successful generate JWT token
            var token = GenerateToken(user);

            // Delete session that have expired
            DeleteExpiredUserSessions();

            // Add a new user's session
            AddSession(user.Id, token);

            var userClientData = new UserClientData()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = token,
                SocketToken = GenerateSocketToken(user.Id)

            };
            return userClientData;

        }

        public string GenerateSocketToken(int userId)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(userId + _secureCode));

                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        // Check if user data is correct
        public User CheckForUserIdentity(string email, string password)
        {
            var user = GetByEmail(email); // check if user exists
            if (user == null) return null;
            return CheckHash(password, user.Password) ? user : null;
        }

        // Register user in DB
        public UserClientData Register(User registeredUser)
        {
            registeredUser.CreatedDateTime = DateTime.Now;
            Add(registeredUser);
            var userClientData = Authenticate(registeredUser);
            return userClientData;
        }

        public User GetByEmail(string email)
        {
            return _userRepository.Get(x => x.Email == email);
        }

        // Generate JWT token for authorization
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_oauthOptions.Secret);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(_defaultUserSessionTimeOut),
                SigningCredentials = credentials
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        // Hash user's password for secure storing in DB
        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 2000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        // Check if user has typed a correct password 
        public bool CheckHash(string typedPassword, string storedPassword)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(storedPassword);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(typedPassword, salt, 2000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }

        // Add new user to DB
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        // Register in DB new user's session
        public void AddSession(int userId, string token)
        {
            var session = new UserSession()
            {
                UserId = userId,
                ExpiryDateTime = DateTime.UtcNow.AddDays(_defaultUserSessionTimeOut),
                Token = token
            };
            _sessionRepository.Add(session);

        }

        // Extend user's session if it is valid
        public bool ReValidateUserSession(string token, string email)
        {
            var currentUserId = GetByEmail(email)?.Id;
            var userSession = _sessionRepository.Get(x => x.UserId == currentUserId && x.Token == token);

            if (userSession == null)
            {
                // User does not have a session with this token --> invalid session
                return false;
            }

            if (userSession.ExpiryDateTime < DateTime.Now)
            {
                // User's session is expired --> invalid session
                return false;
            }

            // Extend the lifetime of the current user's session: current moment + fixed timeout
            userSession.ExpiryDateTime = DateTime.Now.AddDays(_defaultUserSessionTimeOut);
            _sessionRepository.Update(userSession);

            return true;
        }

        public void AddIdentity(UserIdentityKyc userIdentity)
        {
            ;
        }

        // Delete specific user's session from DB
        public void InValidateUserSession(int userId, string token)
        {
            var userSession = _sessionRepository.Get(x => x.UserId == userId && x.Token == token);
            if (userSession != null)
            {
                _sessionRepository.Delete(userSession);
            }
        }

        // Delete all the session with expired date time
        public void DeleteExpiredUserSessions()
        {
            _sessionRepository.Delete(x => x.ExpiryDateTime > DateTime.Now);
        }

        // Update specific user in DB
        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        // Add record about new external login to DB
        public void AddExternalLogin(UserExternalLogin login)
        {
            _externalLoginRepository.Add(login);
        }

        // Get specific external login from DB
        public UserExternalLogin GetExternalLogin(string id, string name)
        {
            return _externalLoginRepository.Get(x => x.ProviderId == id && x.ProviderName == name);
        }

        // Pull user login data via Facebook API
        public async Task<UserFacebookCredentials> GetUserDataViaFacebook(string token)
        {
            using (var http = new HttpClient())
            {
                var postData = new Dictionary<string, string>()
                {
                    {"access_token",token}
                };
                var httpResponse = await http.PostAsync(
                    "https://graph.facebook.com/v2.8/me?fields=id,email,first_name,last_name,gender,locale,birthday,picture",
                    new FormUrlEncodedContent(postData));
                if (httpResponse.StatusCode != HttpStatusCode.OK) return null;
                var resultsData = httpResponse.Content.ReadAsStringAsync().Result;
                var fbCredentials = JsonConvert.DeserializeObject<UserFacebookCredentials>(resultsData);
                return CheckCredentialsForValidity(fbCredentials.Email, fbCredentials.Id) ? fbCredentials : null;
            }
        }

        // Pull user login data via Facebook API
        public async Task<UserGoogleCredentials> GetUserDataViaGoogle(string token)
        {
            using (var http = new HttpClient())
            {
                var postData = new Dictionary<string, string>()
                {
                    {"id_token",token}
                };
                var httpResponse = await http.PostAsync(
                    "https://www.googleapis.com/oauth2/v3/tokeninfo",
                    new FormUrlEncodedContent(postData));
                if (httpResponse.StatusCode != HttpStatusCode.OK) return null;
                var resultsData = httpResponse.Content.ReadAsStringAsync().Result;
                var googleCredentials = JsonConvert.DeserializeObject<UserGoogleCredentials>(resultsData);
                return CheckCredentialsForValidity(googleCredentials.Email, googleCredentials.Id) ? googleCredentials : null;
            }
        }

        // CHECK IF RECEIVED CREDENTIALS ARE VALID
        public bool CheckCredentialsForValidity(string email, string id)
        {
            return email != null && id != null;
        }
    }
}
