using Abp.AutoMapper;
using Ranallo.DocKeeper.Authentication.External;

namespace Ranallo.DocKeeper.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
