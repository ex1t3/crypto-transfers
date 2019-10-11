using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Model.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string EmailVerificationCode { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsExtraLogged { get; set; }

        public ICollection<UserSession> Sessions { get; set; }
        public ICollection<UserExternalLogin> ExternalLogins { get; set; }
        public ICollection<UserIdentityKyc> IdentityKycs { get; set; }
        public UserWallet Wallet { get; set; }
    }

    public class UserWallet
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string BTC { get; set; }
        public string ETH { get; set; }
    }

    public class UserClientSideData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string SocketToken { get; set; }
        public string Email { get; set; }
        public bool IsExtraLogged { get; set; }
        public bool IsEmailVerified { get; set; }
        public UserIdentityViewModel Identity { get; set; }
        public UserWallet Wallets { get; set; }
    }

    public class UserExternalLogin
    {
        [Key]
        public int Id { get; set; }
        public string ProviderId { get; set; }
        public string ProviderName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }

    public class UserLoginViewModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Password should contain at least 4 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
    }

    public class UserSession
    {
        [Key]
        public string Token { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime ExpiryDateTime { get; set; }
    }

    public class UserIdentityKyc
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string ZipCode { get; set; }
        public string Region { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RecordCreatedTime { get; set; }
        public bool IsConfirmed { get; set; }

    }

    public class UserIdentityViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string DialCode;
        public string Number;

        public string ZipCode { get; set; }
        public string Region { get; set; }

        public int Year;
        public int Month;
        public int Day;

    }

    public class OAuthApiCredentials
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FbFirstName
        {
            set => LastName = value;
        }

        [JsonProperty(PropertyName = "last_name")]
        public string FbLastName
        {
            set => FirstName = value;
        }

        [JsonProperty(PropertyName = "id")]
        public string FbId
        {
            set => Id = value;
        }

        [JsonProperty(PropertyName = "sub")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "given_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "family_name")]
        public string LastName { get; set; }
    }
}
