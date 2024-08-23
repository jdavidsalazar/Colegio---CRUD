using AutoMapper;
using School.Src.Core.Domain.Entities;
using School.Src.Presentation.RestApi.Entities;

namespace School.Src.Infrastructure.MySqlDb.Profiles
{
    public class DtoGradoToUpdateProfile : Profile
    {
        public DtoGradoToUpdateProfile()
        {
            CreateMap<DtoGradoToUpdate, Grado>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Nombre, opt => opt.MapFrom(Src => Src.Nombre))
                .ForMember(dst => dst.ProfesorId, opt => opt.MapFrom(Src => Src.ProfesorId));
        }
    }
}
