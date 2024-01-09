using Infrastructure.RateLimit.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Basket.Host
{
    public class RateLimitAttribute : ServiceFilterAttribute
    {
        public RateLimitAttribute() : base(typeof(IRateLimitFilter))
        {
        }
    }

}
