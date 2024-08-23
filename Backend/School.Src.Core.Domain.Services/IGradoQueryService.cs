using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IGradoQueryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Grado>> FindGradosAsync();
    }
}
