using System;

namespace Kliens
{
    public partial class LoginWindow
    {
        public class TokenModel
        {
            public string Token { get; set; }

            public DateTime Expiration { get; set; }
        }
    }
}
