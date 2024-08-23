using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class GradoCommandService : IGradoCommandService
    {
        private readonly IGradoRepository _repository;

        public GradoCommandService(IGradoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Grado>> CreateGradosAsync(IEnumerable<Grado> grados)
        {
            return await _repository.CreateGradosAsync(grados);
        }

        public async Task<Grado> UpdateGradoAsync(Grado grado)
        {
            return await _repository.UpdateGradoAsync(grado);
        }

        public async Task<Grado> DeleteGradoAsync(int id)
        {
            return await _repository.DeleteGradoAsync(id);
        }
    }
}