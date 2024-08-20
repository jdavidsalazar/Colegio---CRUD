using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class AlumnoQueryService : IAlumnoQueryService
    {
        private readonly IAlumnoRepository _repository;
        public AlumnoQueryService(IAlumnoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Alumno>> FindAlumnosAsync() 
        {
            return await _repository.FindAlumnosAsync();
        }
    }
}