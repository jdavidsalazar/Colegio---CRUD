using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class AlumnoGradoQueryService : IAlumnoGradoQueryService
    {
        private readonly IAlumnoGradoRepository _repository;

        public AlumnoGradoQueryService(IAlumnoGradoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<AlumnoGrado>> FindAlumnoGradosAsync()
        {
            return await _repository.FindAlumnoGradosAsync();
        }
    }
}