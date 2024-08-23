using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Services;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/alumnogrados")]
    public class AlumnoGradoCommandController : ControllerBase
    {
        private readonly IAlumnoGradoCommandService _commandService;
        private readonly IMapper _mapper;

        public AlumnoGradoCommandController(IAlumnoGradoCommandService commandService, IMapper mapper)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlumnoGradosAsync([FromBody] IEnumerable<DtoAlumnoGradoToCreate> dtoAlumnoGradoToCreate)
        {
            IEnumerable<AlumnoGrado> alumnoGrados = _mapper.Map<IEnumerable<AlumnoGrado>>(dtoAlumnoGradoToCreate);
            IEnumerable<AlumnoGrado> createdAlumnoGrados = await _commandService.CreateAlumnoGradosAsync(alumnoGrados);
            return Created(string.Empty, createdAlumnoGrados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAlumnoGradoAsync([FromRoute] int id, [FromBody] DtoAlumnoGradoToUpdate dtoAlumnoGradoToUpdate)
        {
            AlumnoGrado alumnoGrado = _mapper.Map<AlumnoGrado>(dtoAlumnoGradoToUpdate);
            alumnoGrado.Id = id;

            return Ok(await _commandService.UpdateAlumnoGradoAsync(alumnoGrado));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnoGradoAsync([FromRoute] int id)
        {
            await _commandService.DeleteAlumnoGradoAsync(id);
            return NoContent();
        }
    }
}
