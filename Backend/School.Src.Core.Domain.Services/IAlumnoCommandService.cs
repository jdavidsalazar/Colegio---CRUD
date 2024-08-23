using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IAlumnoCommandService
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumnos"></param>
        /// <returns></returns>
        public Task<IEnumerable<Alumno>> CreateAlumnosAsync(IEnumerable<Alumno> alumnos);

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public Task<Alumno> UpdateAlumnoAsync(Alumno alumno);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Alumno> DeleteAlumnoAsync(int id);
    }
}
