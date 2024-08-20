using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IAlumnoQueryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Alumno>> FindAlumnosAsync();
    }
}