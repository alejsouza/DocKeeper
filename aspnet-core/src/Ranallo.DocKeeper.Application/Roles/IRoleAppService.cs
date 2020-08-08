using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Ranallo.DocKeeper.Roles.Dto;

namespace Ranallo.DocKeeper.Roles
{
    public interface IDocumentAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
