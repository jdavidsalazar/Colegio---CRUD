using AutoMapper;
using School.Src.Core.Domain.Entities;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class DtoAlumnoToUpdateProfile : Profile
    {
        public DtoAlumnoToUpdateProfile()
        {
            CreateMap<DtoAlumnoToUpdate, Alumno>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(Src => Src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(Src => Src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(Src => Src.Genero))
                .ForMember(dst => dst.FechaNacimiento, opt => opt.MapFrom(Src => Src.FechaNacimiento));
        }
    }
}
