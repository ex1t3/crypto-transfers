using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DbRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using Newtonsoft.Json;

namespace Service.Services
{
    public interface IAccountService
    {
        Task<UserClientSideData> AuthenticateAsync(User user);
        Task<UserClientSideData> RegisterAsync(User user);
        Task<UserClientSideData> GetClientSideDataAsync(User user, string token = null);
        Task<User> CheckForIdentityAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
        Task<OAuthApiCredentials> GetDataViaSocialProvider(string token, string provider);
        string HashPassword(string password);
        void Update(User user);
        Task AddExternalLoginAsync(UserExternalLogin login);
        Task<UserExternalLogin> GetExternalLoginAsync(string id, string name);
        void DeleteExpiredUserSessions();
        void InValidateSession(int userId, string token);
        bool IsSessionValid(string token, string email);
        Task AddIdentityAsync(UserIdentityKyc userIdentity);
        Task<UserIdentityKyc> GetIdentityAsync(int userId);
        Task<UserWallet> GetWalletsAsync(int userId);
        void UpdateWallets(UserWallet wallet);
    }
    public class AccountService : IAccountService
    {
        private readonly IDbRepository<User> _userRepository;
        private readonly IDbRepository<UserSession> _sessionRepository;
        private readonly IDbRepository<UserExternalLogin> _externalLoginRepository;
        private readonly IDbRepository<UserIdentityKyc> _userIdentityRepository;
        private readonly IDbRepository<UserWallet> _userWalletRepository;
        private readonly IMapper _mapper;
        private readonly OAuthSettings _oauthOptions;

        private readonly int _defaultUserSessionTimeOut = 7;
        private readonly string _secureCode = "some_secure_code_#refJHJFHcnn212"; //TODO: More protected code need to be implemented in secure reasons

        private readonly Dictionary<string, string[]> _socialLinks = new Dictionary<string, string[]>()
        {
            { "facebook", new[] {"https://graph.facebook.com/v2.8/me?fields=id,email,first_name,last_name,gender,locale,birthday,picture", "access_token"} },
            { "google", new[] {"https://www.googleapis.com/oauth2/v3/tokeninfo", "id_token"}}
        };

        public AccountService(IDbRepository<User> userRepository, IOptions<OAuthSettings> oauthOptions, IDbRepository<UserSession> sessionRepository, IDbRepository<UserExternalLogin> externalLoginRepository, IDbRepository<UserIdentityKyc> userIdentityRepository, IMapper mapper, IDbRepository<UserWallet> userWalletRepository)
        {
            this._userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _externalLoginRepository = externalLoginRepository;
            _userIdentityRepository = userIdentityRepository;
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _oauthOptions = oauthOptions.Value;
        }

        // Login user and get his unique session token
        public async Task<UserClientSideData> AuthenticateAsync(User user)
        {
            // If login successful generate JWT token
            var token = GenerateAccessToken(user);

            // Delete session that have expired
            DeleteExpiredUserSessions();

            // Add a new user's session
            await AddSessionAsync(user.Id, token);

            return await GetClientSideDataAsync(user, token);

        }

        public async Task<UserIdentityKyc> GetIdentityAsync(int userId)
        {
            return await _userIdentityRepository.GetAsync(x => x.UserId == userId);
        }

        public async Task<UserWallet> GetWalletsAsync(int userId)
        {
            return await _userWalletRepository.GetAsync(x => x.UserId == userId);
        }

        public void UpdateWallets(UserWallet wallet)
        {
            var storedWallet = _userWalletRepository.Get(x => x.UserId == wallet.UserId) ?? wallet;
            if (storedWallet.UserId > 0)
            {
                storedWallet.BTC = wallet.BTC;
                storedWallet.ETH = wallet.ETH;
                _userWalletRepository.Update(storedWallet);
            }
            else
            {
                _userWalletRepository.AddAsync(storedWallet);
            }
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
        public async Task<UserClientSideData> GetClientSideDataAsync(User user, string token = null)
        {
            var mappedIdentity = _mapper.Map<UserIdentityViewModel>(await GetIdentityAsync(user.Id) ?? new UserIdentityKyc());
            return new UserClientSideData()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = token,
                SocketToken = GenerateSocketToken(user.Id),
                Identity = mappedIdentity,
                IsExtraLogged = user.IsExtraLogged,
                IsEmailVerified = user.IsEmailVerified,
                Wallets = await GetWalletsAsync(user.Id) ?? new UserWallet()
            };
        }

        public async Task<User> CheckForIdentityAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email); // check if user exists
            if (user == null) return null;
            return CheckHash(password, user.Password) ? user : null;
        }

        // Register user in DB
        public async Task<UserClientSideData> RegisterAsync(User registeredUser)
        {
            registeredUser.CreatedDateTime = DateTime.Now;
            await AddAsync(registeredUser);
            var userClientData = await AuthenticateAsync(registeredUser);
            return userClientData;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetAsync(x => x.Email == email);
        }

        // Generate JWT token for authorization
        public string GenerateAccessToken(User user)
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
                Expires = DateTime.Now.AddDays(_defaultUserSessionTimeOut),
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
        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        // Register in DB new user's session
        public async Task AddSessionAsync(int userId, string token)
        {
            var session = new UserSession()
            {
                UserId = userId,
                ExpiryDateTime = DateTime.UtcNow.AddDays(_defaultUserSessionTimeOut),
                Token = token
            };
           await _sessionRepository.AddAsync(session);

        }

        // Extend user's session if it is valid
        public bool IsSessionValid(string token, string email)
        {
            var currentUserId = GetByEmailAsync(email)?.Id;
            var userSession = _sessionRepository.Get(x => x.UserId == currentUserId && x.Token == token);

            if (userSession == null)
            {
                // User does not have a session with this token --> invalid session
                return false;
            }

            if (userSession.ExpiryDateTime < DateTime.Now)
            {
                // User's session is expired --> invalid session
                _sessionRepository.Delete(userSession);
                return false;
            }

            // Extend the lifetime of the current user's session: current moment + fixed timeout
            userSession.ExpiryDateTime = DateTime.Now.AddDays(_defaultUserSessionTimeOut);
            _sessionRepository.Update(userSession);

            return true;
        }

        public async Task AddIdentityAsync(UserIdentityKyc userIdentity)
        {
            await _userIdentityRepository.AddAsync(userIdentity);
        }

        // Delete specific user's session from DB
        public void InValidateSession(int userId, string token)
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
            _sessionRepository.Delete(x => x.ExpiryDateTime < DateTime.Now);
        }

        // Update specific user in DB
        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        // Add record about new external login to DB
        public async Task AddExternalLoginAsync(UserExternalLogin login)
        {
            await _externalLoginRepository.AddAsync(login);
        }

        // Get specific external login from DB
        public async  Task<UserExternalLogin> GetExternalLoginAsync(string id, string name)
        {
            return await _externalLoginRepository.GetAsync(x => x.ProviderId == id && x.ProviderName == name);
        }

        // Pull user login data via social provider's API
        public async Task<OAuthApiCredentials> GetDataViaSocialProvider(string token, string provider)
        {
            if (_socialLinks[provider] == null) return null;
            using (var http = new HttpClient())
            {
                var postData = new Dictionary<string, string>()
                {
                    {_socialLinks[provider][1],token}
                };
                var httpResponse = await http.PostAsync(_socialLinks[provider][0], new FormUrlEncodedContent(postData));
                if (httpResponse.StatusCode != HttpStatusCode.OK) return null;
                var resultsData = httpResponse.Content.ReadAsStringAsync().Result;
                var userOAuthData = JsonConvert.DeserializeObject<OAuthApiCredentials>(resultsData);
                return userOAuthData.Id != null ? userOAuthData : null;
            }
        }
    }
}
