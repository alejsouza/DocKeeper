using System.Threading.Tasks;
using Ranallo.DocKeeper.Configuration.Dto;

namespace Ranallo.DocKeeper.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
