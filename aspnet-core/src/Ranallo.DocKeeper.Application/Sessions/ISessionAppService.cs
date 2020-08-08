using System.Threading.Tasks;
using Abp.Application.Services;
using Ranallo.DocKeeper.Sessions.Dto;

namespace Ranallo.DocKeeper.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
