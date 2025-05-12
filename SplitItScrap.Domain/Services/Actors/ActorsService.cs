using SplitItScrap.Domain.Repositories;
using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Actors.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Services.Actors
{
    public class ActorsService : IActorsService
    {
        private readonly IActorRepository _actorRepository;
        
        public ActorsService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task AddActorAsync(Actor actor)
        {
            await _actorRepository.AddActorAsync(actor);
        }
        
        public async Task UpdateActorAsync(Actor actor)
        {
            await _actorRepository.UpdateActorAsync(actor);
        }

        public async Task AddActorsAsync(List<Actor> actors)
        {
            await _actorRepository.AddActorsAsync(actors);
        }

        public async Task DeleteActorAsync(Guid actorId)
        {
            await _actorRepository.DeleteActorAsync(actorId);
        }

        public async Task<Actor> GetActorAsync(Guid actorId)
        {
            return await _actorRepository.GetActorAsync(actorId);
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync(ActorQuery actorQuery)
        {
            return await _actorRepository.GetActorsAsync(actorQuery);
        }
    }
}
