using School.Src.Core.Domain.Entities;
using School.Src.Core.Domain.Repositories;
using School.Src.Infrastructure.MySqlDb.Contexts;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfesorRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Profesor>> FindProfesoresAsync()
        {
            return await _context.Profesores
                .Where(p => p.IsActive)
                .ProjectTo<Profesor>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Profesor>> CreateProfesoresAsync(IEnumerable<Profesor> profesores)
        {
            IEnumerable<DbProfesor> dbProfesores = _mapper.Map<IEnumerable<DbProfesor>>(profesores);
            await _context.Profesores.AddRangeAsync(dbProfesores);
            await _context.SaveChangesAsync();
            IEnumerable<Profesor> createdProfesores = _mapper.Map<IEnumerable<Profesor>>(dbProfesores);
            return createdProfesores;
        }

        public async Task<Profesor> UpdateProfesorAsync(Profesor profesor)
        {
            DbProfesor dbProfesor = await _context.Profesores
                .FirstAsync(p => p.Id == profesor.Id);

            _mapper.Map(profesor, dbProfesor);
            _context.Entry(dbProfesor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<Profesor>(dbProfesor);
        }

        public async Task<Profesor> DeleteProfesorAsync(int id)
        {
            DbProfesor dbProfesor = await _context.Profesores
                .FirstAsync(p => p.Id == id);

            dbProfesor.IsActive = false;
            _context.Entry(dbProfesor).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return _mapper.Map<Profesor>(dbProfesor);
        }
    }
}
