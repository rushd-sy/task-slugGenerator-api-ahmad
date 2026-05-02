using Microsoft.AspNetCore.Mvc;
using SlugApi.DTOs;
namespace SlugApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SlugController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetSlug([FromBody] SlugGenerateRequest request)
        {
            var slug = SlugGenerator.SlugGenerator.Generate(request.Text, request.Separator ?? '-');
            var response = new SlugGenerateResponse
            {
                OriginalText = request.Text,
                Slug = slug,
                GeneratedAt = DateTime.UtcNow
            };
            return Ok(response);
        }
    }
}
