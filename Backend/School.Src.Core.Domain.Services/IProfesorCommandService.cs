using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IProfesorCommandService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesores"></param>
        /// <returns></returns>
        public Task<IEnumerable<Profesor>> CreateProfesoresAsync(IEnumerable<Profesor> profesores);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesor"></param>
        /// <returns></returns>
        public Task<Profesor> UpdateProfesorAsync(Profesor profesor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Profesor> DeleteProfesorAsync(int id);
    }
}
