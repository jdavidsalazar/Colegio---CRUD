using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Services;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("/api/v1/grados")]
    public class GradoCommandController : ControllerBase
    {
        private readonly IGradoCommandService _commandService;
        private readonly IMapper _mapper;

        public GradoCommandController(IGradoCommandService commandService, IMapper mapper)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGradosAsync([FromBody] IEnumerable<DtoGradoToCreate> dtoGradoToCreate)
        {
            IEnumerable<Grado> grados = _mapper.Map<IEnumerable<Grado>>(dtoGradoToCreate);
            IEnumerable<Grado> createdGrados = await _commandService.CreateGradosAsync(grados);
            return Created(string.Empty, createdGrados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGradoAsync([FromRoute] int id, [FromBody] DtoGradoToUpdate dtoGradoToUpdate)
        {
            Grado grado = _mapper.Map<Grado>(dtoGradoToUpdate);
            grado.Id = id;

            return Ok(await _commandService.UpdateGradoAsync(grado));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradoAsync([FromRoute] int id)
        {
            await _commandService.DeleteGradoAsync(id);
            return NoContent();
        }
    }
}
