using School.Src.Core.Domain.Entities;
using School.Src.Infrastructure.MySqlDb.Entities;
using AutoMapper;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class ProfesorProfile : Profile
    {
        public ProfesorProfile()
        {
            CreateMap<DbProfesor, Profesor>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(src => src.Genero));

            CreateMap<Profesor, DbProfesor>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.Apellidos, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(src => src.Genero));
        }
    }
}
