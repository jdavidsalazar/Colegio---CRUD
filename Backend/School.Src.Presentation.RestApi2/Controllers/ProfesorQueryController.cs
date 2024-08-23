using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Services;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/profesores")]
    public class ProfesorQueryController : Controller
    {
        private readonly IProfesorQueryService _service;

        public ProfesorQueryController(IProfesorQueryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> FindProfesoresAsync()
        {
            return Ok(await _service.FindProfesoresAsync());
        }
    }
}
