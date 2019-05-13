using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;

namespace Coursework.API.MapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDTO, Game>()
                .ForMember(dest => dest.Id,
                    src => src.Ignore())
                .ReverseMap();
        }
    }
}
