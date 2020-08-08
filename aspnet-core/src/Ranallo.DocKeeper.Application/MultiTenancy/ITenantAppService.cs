using Abp.Application.Services;
using Ranallo.DocKeeper.MultiTenancy.Dto;

namespace Ranallo.DocKeeper.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

