

namespace JWT.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text.Json;
    using Microsoft.IdentityModel.Tokens;
  

    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
           _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }


  
    }
}
