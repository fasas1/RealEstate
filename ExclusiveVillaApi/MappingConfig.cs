using AutoMapper;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;

namespace ExclusiveVillaApi
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Ville, VilleDTO>();
            CreateMap<VilleDTO, Ville>();

            CreateMap<Ville, VilleCreateDTO>().ReverseMap();
            CreateMap<Ville,VilleCreateDTO>().ReverseMap();
        }
    }
}
