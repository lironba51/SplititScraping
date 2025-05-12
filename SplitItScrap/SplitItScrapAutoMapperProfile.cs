using AutoMapper;
using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Actors.Queries;
using SplitItScrap.Models.Actors;

namespace SplitItScrap
{
    public class SplitItScrapAutoMapperProfile : Profile
    {
        public SplitItScrapAutoMapperProfile()
        {
            CreateActorsMaps();
        }

        private void CreateActorsMaps()
        {
            CreateMap<ActorModelQuery, ActorQuery>();
            CreateMap<Actor, ActorModelView>()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider.ToString()))
                .ReverseMap();
            CreateMap<Actor, ActorModelLstView>();
        }
    }
}
