using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Services;
using School.Src.Infrastructure.MySqlDb.Profiles;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/profesores")]
    public class ProfesorCommandController : ControllerBase
    {
        private readonly IProfesorCommandService _commandService;
        private readonly IMapper _mapper;

        public ProfesorCommandController(IProfesorCommandService commandService, IMapper mapper)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfesoresAsync([FromBody] IEnumerable<DtoProfesorToCreate> dtoProfesorToCreate)
        {
            IEnumerable<Profesor> profesores = _mapper.Map<IEnumerable<Profesor>>(dtoProfesorToCreate);
            IEnumerable<Profesor> createdProfesores = await _commandService.CreateProfesoresAsync(profesores);
            return Created(string.Empty, createdProfesores);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProfesorAsync([FromRoute] int id, [FromBody] DtoProfesorToUpdate dtoProfesorToUpdate)
        {
            Profesor profesor = _mapper.Map<Profesor>(dtoProfesorToUpdate);
            profesor.Id = id;

            return Ok(await _commandService.UpdateProfesorAsync(profesor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesorAsync([FromRoute] int id)
        {
            await _commandService.DeleteProfesorAsync(id);
            return NoContent();
        }
    }
}
