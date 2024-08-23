using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Services;
using School.Src.Infrastructure.MySqlDb.Profiles;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/alumnos")]
    public class AlumnoCommandController : ControllerBase
    {
        private readonly IAlumnoCommandService _commandService;
        private readonly IMapper _mapper;

        public AlumnoCommandController(IAlumnoCommandService commandService, IMapper mapper)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlumnosAsync([FromBody] IEnumerable<DtoAlumnoToCreate> dtoAlumnoToCreate)
        {
            IEnumerable<Alumno> alumnos = _mapper.Map<IEnumerable<Alumno>>(dtoAlumnoToCreate);
            IEnumerable<Alumno> createdAlumnos = await _commandService.CreateAlumnosAsync(alumnos);
            return Created(string.Empty, createdAlumnos);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAlumnoAsync([FromRoute] int id, [FromBody] DtoAlumnoToUpdate dtoAlumnoToUpdate)
        {
            Alumno alumno = _mapper.Map<Alumno>(dtoAlumnoToUpdate);
            alumno.Id = id;

            return Ok(await _commandService.UpdateAlumnoAsync(alumno));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnoAsync([FromRoute] int id)
        {
            await _commandService.DeleteAlumnoAsync(id);
            return NoContent();
        }
    }
}
