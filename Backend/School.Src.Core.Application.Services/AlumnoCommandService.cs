using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Core.Domain.Services;


namespace School.Src.Core.Application.Services
{
    public class AlumnoCommandService : IAlumnoCommandService
    {
        private readonly IAlumnoRepository _repository;

        public AlumnoCommandService(IAlumnoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Alumno>> CreateAlumnosAsync(IEnumerable<Alumno> alumnos)
        {       
            return await _repository.CreateAlumnosAsync(alumnos);
        }

        public async Task<Alumno> UpdateAlumnoAsync(Alumno alumno)
        {
            return await _repository.UpdateAlumnoAsync(alumno);
        }

        public async Task<Alumno> DeleteAlumnoAsync(int id)
        {
            return await _repository.DeleteAlumnoAsync(id);
        }
    }
}
