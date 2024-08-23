using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Infrastructure.MySqlDb.Contexts;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Repositories
{
    public class AlumnoGradoRepository : IAlumnoGradoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlumnoGradoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AlumnoGrado>> FindAlumnoGradosAsync()
        {
            return await _context.AlumnoGrado
                .Where(ag => ag.IsActive)
                .ProjectTo<AlumnoGrado>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlumnoGrado>> CreateAlumnoGradosAsync(IEnumerable<AlumnoGrado> alumnoGrados)
        {
            IEnumerable<DbAlumnoGrado> dbAlumnoGrados = _mapper.Map<IEnumerable<DbAlumnoGrado>>(alumnoGrados);
            await _context.AlumnoGrado.AddRangeAsync(dbAlumnoGrados);
            await _context.SaveChangesAsync();
            IEnumerable<AlumnoGrado> createdAlumnoGrados = _mapper.Map<IEnumerable<AlumnoGrado>>(dbAlumnoGrados);
            return createdAlumnoGrados;
        }

        public async Task<AlumnoGrado> UpdateAlumnoGradoAsync(AlumnoGrado alumnoGrado)
        {
            DbAlumnoGrado dbAlumnoGrado = await _context.AlumnoGrado
                .FirstAsync(ag => ag.Id == alumnoGrado.Id);

            _mapper.Map(alumnoGrado, dbAlumnoGrado);
            _context.Entry(dbAlumnoGrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<AlumnoGrado>(dbAlumnoGrado);
        }

        public async Task<AlumnoGrado> DeleteAlumnoGradoAsync(int id)
        {
            DbAlumnoGrado dbAlumnoGrado = await _context.AlumnoGrado
                .FirstAsync(ag => ag.Id == id);

            _context.Entry(dbAlumnoGrado).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return _mapper.Map<AlumnoGrado>(dbAlumnoGrado);
        }
    }
}
