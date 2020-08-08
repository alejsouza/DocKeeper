using System.Collections.Generic;

namespace Ranallo.DocKeeper.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
