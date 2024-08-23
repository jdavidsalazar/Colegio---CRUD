using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Services;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/alumnos")]
    public class AlumnoQueryController : Controller
    {
        private readonly IAlumnoQueryService _service;
        public AlumnoQueryController(IAlumnoQueryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> FindAlumnosAsync()
        {
            return Ok(await _service.FindAlumnosAsync());
        }
    }
}
