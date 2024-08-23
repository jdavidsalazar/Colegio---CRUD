using AutoMapper;
using School.Src.Core.Domain.Entities;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class DtoAlumnoGradoToCreateProfile : Profile
    {
        public DtoAlumnoGradoToCreateProfile()
        {
            CreateMap<DtoAlumnoGradoToCreate, AlumnoGrado>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.AlumnoId, opt => opt.MapFrom(Src => Src.AlumnoId))
                .ForMember(dst => dst.GradoId, opt => opt.MapFrom(Src => Src.GradoId))
                .ForMember(dst => dst.Grupo, opt => opt.MapFrom(Src => Src.Grupo));
        }
    }
}
