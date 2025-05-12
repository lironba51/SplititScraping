using SplitItScrap.Domain.Services.Actors.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Services.Providers
{
    public interface IProvider
    {
        Task<IEnumerable<Actor>> GetActorsAsync();
    }
}
