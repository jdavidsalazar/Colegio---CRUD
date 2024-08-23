using School.Src.Core.Domain.Entities;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class AlumnoProfile : Profile
    {
        public AlumnoProfile() 
        {
            CreateMap<DbAlumno, Alumno>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(Src => Src.Id))
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(Src => Src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(Src => Src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(Src => Src.Genero))
                .ForMember(dst => dst.FechaNacimiento, opt => opt.MapFrom(Src => Src.FechaNacimiento));

            CreateMap<Alumno, DbAlumno>()
               .ForMember(dst => dst.Id, opt => opt.Ignore())
               .ForMember(dst => dst.Nombre, opt => opt.MapFrom(Src => Src.Nombre))
               .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(Src => Src.Apellidos))
               .ForMember(dst => dst.Genero, opt => opt.MapFrom(Src => Src.Genero))
               .ForMember(dst => dst.FechaNacimiento, opt => opt.MapFrom(Src => Src.FechaNacimiento));
        }
    }
}
