using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Ranallo.DocKeeper.Roles.Dto;
using Ranallo.DocKeeper.Users.Dto;

namespace Ranallo.DocKeeper.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
