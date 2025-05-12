using SplitItScrap.Domain.Services.Actors.Entities;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Services.Uploads
{
    public interface IUploadService
    {
        Task HandleActorsAsync();
    }
}
