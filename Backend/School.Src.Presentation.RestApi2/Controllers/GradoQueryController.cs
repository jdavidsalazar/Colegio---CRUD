using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Services;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/grados")]
    public class GradoQueryController : Controller
    {
        private readonly IGradoQueryService _service;

        public GradoQueryController(IGradoQueryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> FindGradosAsync()
        {
            return Ok(await _service.FindGradosAsync());
        }
    }
}
