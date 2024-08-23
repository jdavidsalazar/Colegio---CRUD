using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class ProfesorCommandService : IProfesorCommandService
    {
        private readonly IProfesorRepository _repository;

        public ProfesorCommandService(IProfesorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Profesor>> CreateProfesoresAsync(IEnumerable<Profesor> profesores)
        {
            return await _repository.CreateProfesoresAsync(profesores);
        }

        public async Task<Profesor> UpdateProfesorAsync(Profesor profesor)
        {
            return await _repository.UpdateProfesorAsync(profesor);
        }

        public async Task<Profesor> DeleteProfesorAsync(int id)
        {
            return await _repository.DeleteProfesorAsync(id);
        }
    }
}
