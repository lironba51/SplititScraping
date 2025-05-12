using SplitItScrap.Domain.Services.Actors;
using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitItScrap.Domain.Services.Uploads
{
    public class UploadService : IUploadService
    {
        private readonly IProviderFactory _providerFactory;
        private readonly IActorsService _actorsService;
        private readonly List<ProviderTypeCode> _providerTypeCodes;
        public UploadService(IProviderFactory providerFactory, IActorsService actorsService)
        {
            _providerFactory = providerFactory;
            _actorsService = actorsService;
            _providerTypeCodes = new List<ProviderTypeCode>()
            {
                ProviderTypeCode.IMDB
            };
        }

        public async Task HandleActorsAsync()
        {
            foreach (var providerTypeCode in _providerTypeCodes)
            {
                var provider = _providerFactory.GetProvider(providerTypeCode);
                var actors = await provider.GetActorsAsync();

                await _actorsService.AddActorsAsync(actors.ToList());   
            }
        }
    }
}
