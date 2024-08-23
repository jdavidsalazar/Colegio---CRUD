using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Repositories
{
    public interface IAlumnoRepository
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
        /// <returns></returns>
        public Task<IEnumerable<Alumno>> FindAlumnosAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedAlumno"></param>
        /// <returns></returns>
        public Task<Alumno> UpdateAlumnoAsync(Alumno updatedAlumno);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Alumno> DeleteAlumnoAsync(int id);
    }
}
