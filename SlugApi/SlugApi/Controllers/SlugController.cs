using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using SlugApi.DTOs;
namespace SlugApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/slug")]
    public class SlugController : ControllerBase
    {
        [HttpPost]
        [EnableRateLimiting(policyName: "IpPolicy")]
        public ActionResult<GenerateSlugResponse> GenerateSlug([FromBody] GenerateSlugRequest request,[FromServices] IMemoryCache cache)
        {
            var cachekey = $"Slug_{request.Text}_{request.Separator ?? '-'}";
            if(cache.TryGetValue(cachekey , out GenerateSlugResponse? cashedSlug ))
            {
                Response.Headers.Append("X_Cache","HIT");
                return Ok(cashedSlug!); }
            var slug = SlugGenerator.SlugGenerator.Generate(request.Text, request.Separator ?? '-');
            var response = new GenerateSlugResponse
            {
                OriginalText = request.Text,
                Slug = slug
            };
            Response.Headers.Append("X_Cache", "MISS");
            cache.Set(cachekey, response);
            return Ok(response);
        }
    }
}
