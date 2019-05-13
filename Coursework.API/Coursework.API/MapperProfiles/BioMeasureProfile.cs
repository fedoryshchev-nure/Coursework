using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class BioMeasureProfile : Profile
    {
        public BioMeasureProfile()
        {
            CreateMap<BioMeasureDTO, BioMeasure>()
                .ForMember(dest => dest.Id,
                    src => src.Ignore())
                .ReverseMap();
        }
    }
}
