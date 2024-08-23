using School.Src.Core.Domain.Entities;

namespace School.Src.Infrastructure.MySqlDb.Entities
{
    public class DbGrado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public bool IsActive { get; set; } = true;

        //Navigation property
        public Profesor Profesor { get; set; }
    }
}
