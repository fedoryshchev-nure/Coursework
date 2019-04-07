using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<MatchDTO, Match>()
                .ReverseMap();
        }
    }
}
