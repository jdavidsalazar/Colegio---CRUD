using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class AlumnoGradoCommandService : IAlumnoGradoCommandService
    {
        private readonly IAlumnoGradoRepository _repository;

        public AlumnoGradoCommandService(IAlumnoGradoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<AlumnoGrado>> CreateAlumnoGradosAsync(IEnumerable<AlumnoGrado> alumnoGrados)
        {
            return await _repository.CreateAlumnoGradosAsync(alumnoGrados);
        }

        public async Task<AlumnoGrado> UpdateAlumnoGradoAsync(AlumnoGrado alumnoGrado)
        {
            return await _repository.UpdateAlumnoGradoAsync(alumnoGrado);
        }

        public async Task<AlumnoGrado> DeleteAlumnoGradoAsync(int id)
        {
            return await _repository.DeleteAlumnoGradoAsync(id);
        }
    }
}
