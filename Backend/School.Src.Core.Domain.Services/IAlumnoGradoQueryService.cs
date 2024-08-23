using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IAlumnoGradoQueryService
    {
        /// <summary>
        /// Find all AlumnoGrado records asynchronously.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AlumnoGrado>> FindAlumnoGradosAsync();
    }
}
