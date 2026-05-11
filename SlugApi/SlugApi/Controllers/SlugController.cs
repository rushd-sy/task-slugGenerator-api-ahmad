using Microsoft.AspNetCore.Mvc;
using SlugApi.DTOs;
namespace SlugApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SlugController : ControllerBase
    {
        [HttpPost]
        public ActionResult<GenerateSlugResponse> GenerateSlug([FromBody] GenerateSlugRequest request)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(request.Text);
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
