using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SlugApi.DTOs;
namespace SlugApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/slug")]
    public class SlugController : ControllerBase
    {
        [HttpPost]
        public ActionResult<GenerateSlugResponse> GenerateSlug([FromBody] GenerateSlugRequest request)
        {
            var slug = SlugGenerator.SlugGenerator.Generate(request.Text, request.Separator ?? '-');
            var response = new GenerateSlugResponse
            {
                OriginalText = request.Text,
                Slug = slug
            };
            return Ok(response);
        }
    }
}
