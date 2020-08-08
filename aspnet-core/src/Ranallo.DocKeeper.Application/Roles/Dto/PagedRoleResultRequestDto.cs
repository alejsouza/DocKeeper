using Abp.Application.Services.Dto;

namespace Ranallo.DocKeeper.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

