using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Services
{
    public interface IGradoCommandService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grados"></param>
        /// <returns></returns>
        public Task<IEnumerable<Grado>> CreateGradosAsync(IEnumerable<Grado> grados);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grado"></param>
        /// <returns></returns>
        public Task<Grado> UpdateGradoAsync(Grado grado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Grado> DeleteGradoAsync(int id);
    }
}
