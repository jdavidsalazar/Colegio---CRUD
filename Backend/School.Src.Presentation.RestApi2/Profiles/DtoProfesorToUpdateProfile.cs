using AutoMapper;
using School.Src.Core.Domain.Entities;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class DtoProfesorToUpdateProfile : Profile
    {
        public DtoProfesorToUpdateProfile()
        {
            CreateMap<DtoProfesorToUpdate, Profesor>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(Src => Src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(Src => Src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(Src => Src.Genero));
        }
    }
}
