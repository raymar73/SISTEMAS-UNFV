
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Authentication
{
    public class JsonWebTokenAdmPanel
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public float Expires_in { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }

    }
}
