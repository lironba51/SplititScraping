using SplitItScrap.Domain.Services.Actors.Entities;

namespace SplitItScrap.Domain.Services.Providers
{
    public interface IProviderFactory
    {
        IProvider GetProvider(ProviderTypeCode providerTypeCode);
    }
}
