using SplitItScrap.Domain.Services.Actors.Entities;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace SplitItScrap.Domain.Services.Providers
{
    public class ProviderFactory : IProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProvider GetProvider(ProviderTypeCode providerTypeCode)
        {
            return providerTypeCode switch
            {
                ProviderTypeCode.IMDB => _serviceProvider.GetRequiredService<IMDBProvider>(),
                _ => throw new ArgumentOutOfRangeException(nameof(providerTypeCode))
            };
        }
    }
}
