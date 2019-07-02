using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsExtraLogged { get; set; }

        public ICollection<UserSession> UserSessions { get; set; }
        public ICollection<UserExternalLogin> UserExternalLogins { get; set; }
    }

    public class UserClientData
    {
        public string FullName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public bool IsExtraLogged { get; set; }
    }

    public class UserExternalLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProviderId { get; set; }
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

        public string Fullname { get; set; }
    }

    public class UserSession
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDateTime { get; set; }
    }

    public class FacebookCredentials
    { 
        public string email { get; set; }
        public string name { get; set; }
        // Provider ID
        public long id { get; set; }
    }
}
