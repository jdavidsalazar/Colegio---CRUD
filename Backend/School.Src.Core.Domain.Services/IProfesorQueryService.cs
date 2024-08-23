using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IProfesorQueryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Profesor>> FindProfesoresAsync();
    }
}
