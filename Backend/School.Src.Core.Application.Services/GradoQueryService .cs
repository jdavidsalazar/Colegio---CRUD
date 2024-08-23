using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;

namespace School.Src.Core.Application.Services
{
    public class GradoQueryService : IGradoQueryService
    {
        private readonly IGradoRepository _repository;

        public GradoQueryService(IGradoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Grado>> FindGradosAsync()
        {
            return await _repository.FindGradosAsync();
        }
    }
}
