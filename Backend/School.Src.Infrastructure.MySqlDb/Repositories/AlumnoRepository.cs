using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Infrastructure.MySqlDb.Contexts;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlumnoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Alumno>> FindAlumnosAsync()
        {
            return await _context.Alumnos
                .Where(a => a.IsActive)
                .ProjectTo<Alumno>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alumno>> CreateAlumnosAsync(IEnumerable<Alumno> alumnos)
        {
            IEnumerable<DbAlumno> dbAlumnos = _mapper.Map<IEnumerable<DbAlumno>>(alumnos);
            await _context.Alumnos.AddRangeAsync(dbAlumnos);
            await _context.SaveChangesAsync();
            IEnumerable<Alumno> createdAlumnos = _mapper.Map<IEnumerable<Alumno>>(dbAlumnos);
            return createdAlumnos;
        }

        public async Task<Alumno> UpdateAlumnoAsync(Alumno alumno)
        {
            DbAlumno dbAlumno = await _context.Alumnos
                .FirstAsync(a => a.Id == alumno.Id);

            _mapper.Map(alumno, dbAlumno);
            _context.Entry(dbAlumno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<Alumno>(dbAlumno);
        }

        public async Task<Alumno> DeleteAlumnoAsync(int id)
        {
            DbAlumno dbAlumno = await _context.Alumnos
                .FirstAsync(a => a.Id == id);

            dbAlumno.IsActive = false;
            _context.Entry(dbAlumno).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return _mapper.Map<Alumno>(dbAlumno);
        }
    }
}