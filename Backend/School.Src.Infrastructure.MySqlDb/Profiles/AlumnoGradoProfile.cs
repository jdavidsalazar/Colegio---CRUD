using School.Src.Core.Domain.Entities;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class AlumnoGradoProfile : Profile
    {
        public AlumnoGradoProfile()
        {
            CreateMap<DbAlumnoGrado, AlumnoGrado>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.AlumnoId, opt => opt.MapFrom(src => src.AlumnoId))
                .ForMember(dst => dst.GradoId, opt => opt.MapFrom(src => src.GradoId))
                .ForMember(dst => dst.Grupo, opt => opt.MapFrom(src => src.Grupo));

            CreateMap<AlumnoGrado, DbAlumnoGrado>()
             .ForMember(dst => dst.Id, opt => opt.Ignore())
             .ForMember(dst => dst.AlumnoId, opt => opt.MapFrom(src => src.AlumnoId))
             .ForMember(dst => dst.GradoId, opt => opt.MapFrom(src => src.GradoId))
             .ForMember(dst => dst.Grupo, opt => opt.MapFrom(src => src.Grupo));
        }
    }
}
