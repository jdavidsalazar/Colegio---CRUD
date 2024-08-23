using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IAlumnoGradoCommandService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumnoGrados"></param>
        /// <returns></returns>
        public Task<IEnumerable<AlumnoGrado>> CreateAlumnoGradosAsync(IEnumerable<AlumnoGrado> alumnoGrados);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumnoGrado"></param>
        /// <returns></returns>
        public Task<AlumnoGrado> UpdateAlumnoGradoAsync(AlumnoGrado alumnoGrado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AlumnoGrado> DeleteAlumnoGradoAsync(int id);
    }
}
