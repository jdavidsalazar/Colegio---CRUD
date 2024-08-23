using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Services;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/alumnogrados")]
    public class AlumnoGradoQueryController : Controller
    {
        private readonly IAlumnoGradoQueryService _service;

        public AlumnoGradoQueryController(IAlumnoGradoQueryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> FindAlumnoGradosAsync()
        {
            var result = await _service.FindAlumnoGradosAsync();
            return Ok(result);
        }
    }
}
