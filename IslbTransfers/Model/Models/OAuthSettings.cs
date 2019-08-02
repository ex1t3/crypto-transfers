using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class OAuthSettings
    {
        public string Secret { get; set; }
    }

    public class OAuthProviderAccess
    {
        public string Token { get; set; }
        private string _provider;
        public string Provider
        {
            get => _provider;
            set => _provider = value.ToLower();
        }
    }
}
