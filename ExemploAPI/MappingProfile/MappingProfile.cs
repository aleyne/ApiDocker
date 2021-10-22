using ApiDocker.DTO;
using ApiDocker.Entities;
using AutoMapper;

namespace CDIEMS.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Orgao, OrgaoSemLogo>();
            CreateMap<Orgao, OrgaoComLogo>();
        }
    }
}
