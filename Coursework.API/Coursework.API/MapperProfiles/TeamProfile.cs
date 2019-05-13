using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDTO, Team>()
                .ForMember(dest => dest.Id,
                    src => src.Ignore())
                .ReverseMap();
        }
    }
}
