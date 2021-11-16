using AutoMapper;

namespace PCI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StandUp, StandUpResource>();
        }
    }
}