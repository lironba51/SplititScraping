using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Actors.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Repositories
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsAsync(ActorQuery actorQuery);

        Task<Actor> GetActorAsync(Guid actorId);

        Task AddActorAsync(Actor actor);

        Task UpdateActorAsync(Actor actor);

        Task AddActorsAsync(List<Actor> actors);

        Task DeleteActorAsync(Guid actorId);
    }
}
