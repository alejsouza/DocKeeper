using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Ranallo.DocKeeper.Documents.Dto;

namespace Ranallo.DocKeeper.Documents
{
    public interface IDocumentsAppService : IAsyncCrudAppService<DocumentDto, long, PagedDocumentResultRequestDto, CreateDocumentDto, DocumentDto>
    {
        Task<PagedResultDto<GetDocumentForViewDto>> GetDocumentsAsync(PagedDocumentResultRequestDto input);

        Task<GetDocumentForViewDto> GetDocumentForView(long id);

		Task<GetDocumentForEditOutput> GetDocumentForEdit(EntityDto<long> input);
		
    }
}