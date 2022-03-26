

namespace JWT.Authentication
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    public interface ITokenProvider
    {
        TokenValidationParameters GetValidationParameters();
    }
}
