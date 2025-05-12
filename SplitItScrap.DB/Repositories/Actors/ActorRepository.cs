using Microsoft.EntityFrameworkCore;
using SplitItScrap.Domain.ErrorHandlers.Actors;
using SplitItScrap.Domain.Repositories;
using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Actors.Queries;

namespace SplitItScrap.DB.Repositories.Actors
{
    public class ActorRepository: IActorRepository
    {
        private readonly SplitItScrapDbContext _splitItScrapDbContext;
        
        public ActorRepository(SplitItScrapDbContext splitItScrapDbContext)
        {
            _splitItScrapDbContext = splitItScrapDbContext;
        }

        public async Task AddActorAsync(Actor actor)
        {
            _splitItScrapDbContext.Actors.Add(actor);
            await _splitItScrapDbContext.SaveChangesAsync();
        }
        
        public async Task AddActorsAsync(List<Actor> actors)
        {
            _splitItScrapDbContext.Actors.AddRange(actors);
            await _splitItScrapDbContext.SaveChangesAsync();
        }

        public async Task DeleteActorAsync(Guid actorId)
        {
            var actor = await _splitItScrapDbContext.Actors.FindAsync(actorId);
            if (actor != null)
            {
                _splitItScrapDbContext.Actors.Remove(actor);
                await _splitItScrapDbContext.SaveChangesAsync();
            }
        }

        public async Task<Actor> GetActorAsync(Guid actorId)
        {
            var actor =  await _splitItScrapDbContext.Actors
                .Where(a => a.Id == actorId)
                .FirstOrDefaultAsync();

            if (actor == null)
            {
                throw new ActorNotFoundException($"Actor with ID {actorId} was not found.");
            }

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync(ActorQuery actorQuery)
        {
            IQueryable<Actor> query = _splitItScrapDbContext.Actors.Skip(actorQuery.Skip).Take(actorQuery.Take);

            if (!string.IsNullOrEmpty(actorQuery.ActorName))
            {
                query = query.Where(a => a.Name.Contains(actorQuery.ActorName, StringComparison.OrdinalIgnoreCase));
            }

            if (actorQuery.MinRank.HasValue)
            {
                query = query.Where(a => a.Rank >= actorQuery.MinRank);
            }

            if (actorQuery.MaxRank.HasValue)
            {
                query = query.Where(a => a.Rank <= actorQuery.MaxRank);
            }

            return await query.ToListAsync();
        }

        public async Task UpdateActorAsync(Actor actor)
        {
            _splitItScrapDbContext.Actors.Update(actor);
            await _splitItScrapDbContext.SaveChangesAsync();
            //var existingActor = await _splitItScrapDbContext.Actors.FindAsync(actor.Id);
            //if (existingActor != null)
            //{
            //    existingActor.Name = actor.Name;
            //    existingActor.Type = actor.Type;
            //    existingActor.Rank = actor.Rank;
            //    existingActor.Details = actor.Details;
            //    existingActor.Provider = actor.Provider;

            //    await _splitItScrapDbContext.SaveChangesAsync();
            //}
        }
    }
}
