using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT
{
    public interface ITokenManager
    {
        Task DesactivateAsync(string token);
        Task<bool> IsActiveAsync(string token);
        Task<bool> IsCurrentActiveToken();
        Task DesactivateCurrentAsync();
    }
}
