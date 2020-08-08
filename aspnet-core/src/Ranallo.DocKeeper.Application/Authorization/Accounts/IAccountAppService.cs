using System.Threading.Tasks;
using Abp.Application.Services;
using Ranallo.DocKeeper.Authorization.Accounts.Dto;

namespace Ranallo.DocKeeper.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
