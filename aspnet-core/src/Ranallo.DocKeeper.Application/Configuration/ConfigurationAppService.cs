using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Ranallo.DocKeeper.Configuration.Dto;

namespace Ranallo.DocKeeper.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DocKeeperAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
