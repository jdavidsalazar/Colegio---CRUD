using School.Src.Core.Domain.Entities;

namespace School.Src.Infrastructure.MySqlDb.Entities
{
    public class DbAlumnoGrado
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int GradoId { get; set; }
        public string Grupo { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public DbAlumno Alumno { get; set; }
        public DbGrado Grado { get; set; }
    }
}
