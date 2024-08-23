using AutoMapper;
using School.Src.Core.Domain.Entities;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class DtoProfesorToCreateProfile : Profile
    {
        public DtoProfesorToCreateProfile()
        {
            CreateMap<DtoProfesorToCreate, Profesor>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(src => src.Genero));
        }
    }
}
