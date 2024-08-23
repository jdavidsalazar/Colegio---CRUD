using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Infrastructure.MySqlDb.Contexts;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Repositories
{
    public class GradoRepository : IGradoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GradoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Grado>> FindGradosAsync()
        {
            return await _context.Grados
                .Where(a => a.IsActive)
                .ProjectTo<Grado>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Grado>> CreateGradosAsync(IEnumerable<Grado> grados)
        {
            IEnumerable<DbGrado> dbGrados = _mapper.Map<IEnumerable<DbGrado>>(grados);
            await _context.Grados.AddRangeAsync(dbGrados);
            await _context.SaveChangesAsync();
            IEnumerable<Grado> createdGrados = _mapper.Map<IEnumerable<Grado>>(dbGrados);
            return createdGrados;
        }

        public async Task<Grado> UpdateGradoAsync(Grado grado)
        {
            DbGrado dbGrado = await _context.Grados
                .FirstAsync(g => g.Id == grado.Id);

            _mapper.Map(grado, dbGrado);
            _context.Entry(dbGrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<Grado>(dbGrado);
        }

        public async Task<Grado> DeleteGradoAsync(int id)
        {
            DbGrado dbGrado = await _context.Grados
                .FirstAsync(g => g.Id == id);

            _context.Entry(dbGrado).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return _mapper.Map<Grado>(dbGrado);
        }
    }
}
