using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DAL.DbRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Models;

namespace Service.Services
{
    public interface IUserService
    {
        UserClientData Authenticate(User user);
        UserClientData Register(UserLoginViewModel user);
        User CheckForUserIdentity(string email, string password);
        string HashPassword(string password);
        bool CheckHash(string typedPassword, string storedPassword);
        void Add(User user);
        void AddSession(int userId, string token);
        void Update(User user);
    }
    public class UserService : IUserService
    {
        private readonly IDbRepository<User> _userRepository;
        private readonly IDbRepository<UserSession> _sessionRepository;
        private readonly OAuthSettings _oauthOptions;

        public UserService(IDbRepository<User> userRepository, IOptions<OAuthSettings> oauthOptions, IDbRepository<UserSession> sessionRepository)
        {
            this._userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _oauthOptions = oauthOptions.Value;
        }

        // Login user and get his unique session token
        public UserClientData Authenticate(User user)
        {
            // If login successful generate JWT token
            var token = GenerateToken(user);

            // Add a new user's session
            AddSession(user.Id, token);

            var userClientData = new UserClientData()
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = token,

            };
            return userClientData;

        }

        // Check if user data is correct
        public User CheckForUserIdentity(string email, string password)
        {
            var user = _userRepository.Get(x => x.Email == email); // check if user exists
            if (user == null) return null;
            return CheckHash(password, user.Password) ? user : null;
        }

        // Register user in DB
        public UserClientData Register(UserLoginViewModel user)
        {
            if (_userRepository.Get(x => x.Email == user.Email) != null) return null;
            var registeredUser = new User()
            {
                Email = user.Email,
                Password = user.Password
            };
            Add(registeredUser);
            var userClientData = Authenticate(registeredUser);
            return userClientData;
        }

        // Generate JWT token for authorization
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_oauthOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email), 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
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
            user.Password = HashPassword(user.Password);
            _userRepository.Add(user);
        }

        public void AddSession(int userId, string token)
        {
            var session = new UserSession()
            {
                UserId = userId,
                ExpiryDateTime = DateTime.UtcNow.AddDays(7),
                Token = token
            };
            _sessionRepository.Add(session);

        }

        // Update specific user in DB
        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
