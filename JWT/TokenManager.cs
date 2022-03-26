using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT
{
    public class TokenManager : ITokenManager
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public TokenManager(IDistributedCache cache, IHttpContextAccessor httpContextAccesor)
        {
            _cache = cache;
            _httpContextAccesor = httpContextAccesor;
        }
        public async Task DesactivateAsync(string token)
        {
            await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
        }

        private static string GetKey(string token)
             => $"tokens:{token}:deactivated";

        public async Task<bool> IsCurrentActiveToken()
          => await IsActiveAsync(GetCurrentAsync());

        public async Task<bool> IsActiveAsync(string token)
          => await _cache.GetStringAsync(GetKey(token)) == null;

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccesor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? String.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        public async Task DesactivateCurrentAsync()
         => await DesactivateAsync(GetCurrentAsync());
    }
}
