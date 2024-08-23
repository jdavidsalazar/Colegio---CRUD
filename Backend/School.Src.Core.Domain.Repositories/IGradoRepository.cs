using School.Src.Core.Domain.Entities;

namespace School.Src.Core.Domain.Repositories
{
    public interface IGradoRepository
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
        /// <returns></returns>
        public Task<IEnumerable<Grado>> FindGradosAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedGrado"></param>
        /// <returns></returns>
        public Task<Grado> UpdateGradoAsync(Grado updatedGrado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Grado> DeleteGradoAsync(int id);
    }
}
