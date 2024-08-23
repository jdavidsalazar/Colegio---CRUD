using School.Src.Core.Domain.Entities;
using School.Src.Infrastructure.MySqlDb.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class GradoProfile : Profile
    {
        public GradoProfile()
        {
            CreateMap<DbGrado, Grado>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.ProfesorId, opt => opt.MapFrom(src => src.ProfesorId));

            CreateMap<Grado, DbGrado>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.ProfesorId, opt => opt.MapFrom(src => src.ProfesorId));
        }
    }
}
