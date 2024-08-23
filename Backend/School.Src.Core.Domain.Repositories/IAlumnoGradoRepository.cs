using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Repositories
{
    public interface IAlumnoGradoRepository
    {
        /// <summary>
        /// Create multiple AlumnoGrado records asynchronously.
        /// </summary>
        /// <param name="alumnoGrados"></param>
        /// <returns></returns>
        public Task<IEnumerable<AlumnoGrado>> CreateAlumnoGradosAsync(IEnumerable<AlumnoGrado> alumnoGrados);

        /// <summary>
        /// Find all AlumnoGrado records asynchronously.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AlumnoGrado>> FindAlumnoGradosAsync();

        /// <summary>
        /// Update an existing AlumnoGrado record asynchronously.
        /// </summary>
        /// <param name="updatedAlumnoGrado"></param>
        /// <returns></returns>
        public Task<AlumnoGrado> UpdateAlumnoGradoAsync(AlumnoGrado updatedAlumnoGrado);

        /// <summary>
        /// Delete an AlumnoGrado record by Id asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AlumnoGrado> DeleteAlumnoGradoAsync(int id);
    }
}
