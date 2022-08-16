using System;

namespace UniUti.WebAPI.ViewModels
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
