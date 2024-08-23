using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DbAlumno> Alumnos { get; set; }
        public DbSet<DbProfesor> Profesores { get; set; }
        public DbSet<DbGrado> Grados { get; set; }
        public DbSet<DbAlumnoGrado> AlumnoGrado { get; set; }
    }
}
