using School.Src.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Src.Core.Domain.Repositories
{
    public interface IProfesorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesores"></param>
        /// <returns></returns>
        Task<IEnumerable<Profesor>> CreateProfesoresAsync(IEnumerable<Profesor> profesores);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Profesor>> FindProfesoresAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedProfesor"></param>
        /// <returns></returns>
        Task<Profesor> UpdateProfesorAsync(Profesor updatedProfesor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Profesor> DeleteProfesorAsync(int id);
    }
}
