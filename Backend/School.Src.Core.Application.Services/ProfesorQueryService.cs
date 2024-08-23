using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class ProfesorQueryService : IProfesorQueryService
    {
        private readonly IProfesorRepository _repository;

        public ProfesorQueryService(IProfesorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Profesor>> FindProfesoresAsync()
        {
            return await _repository.FindProfesoresAsync();
        }
    }
}
