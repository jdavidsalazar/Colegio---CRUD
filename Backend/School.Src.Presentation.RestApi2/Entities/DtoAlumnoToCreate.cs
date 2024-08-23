namespace School.Src.Presentation.RestApi.Entities
{
    public class DtoAlumnoToCreate
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
