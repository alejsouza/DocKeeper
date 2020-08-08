using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Ranallo.DocKeeper.Documents.Dto;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Ranallo.DocKeeper.Authorization;
using Abp.Application.Services;

namespace Ranallo.DocKeeper.Documents
{
    [AbpAuthorize(PermissionNames.Pages_Documents)]
    public class DocumentsAppService : AsyncCrudAppService<Document, DocumentDto, long,
                                                            PagedDocumentResultRequestDto, 
                                                            CreateDocumentDto, 
                                                            DocumentDto>, IDocumentsAppService
    {
        private readonly IRepository<Document, long> _documentRepository;

        public DocumentsAppService(IRepository<Document, long> documentRepository) : base(documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public override async Task<DocumentDto> CreateAsync(CreateDocumentDto input)
        {
            var document = ObjectMapper.Map<Document>(input);

            if (AbpSession.TenantId != null)
            {
                document.TenantId = (int?)AbpSession.TenantId;
            }

            await _documentRepository.InsertAsync(document);

            return MapToEntityDto(document);
        }
        
        public async Task<PagedResultDto<GetDocumentForViewDto>> GetDocumentsAsync(PagedDocumentResultRequestDto input)
        {

            var filteredDocuments = _documentRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LocationFilter), e => e.Location == input.LocationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);
        
            var pagedAndFilteredDocuments = filteredDocuments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var documents = from o in pagedAndFilteredDocuments
                            select new GetDocumentForViewDto()
                            {
                                Document = new DocumentDto
                                {
                                    Name = o.Name,
                                    Location = o.Location,
                                    Description = o.Description,
                                    FileId = o.FileId,
                                    Id = o.Id
                                }
                            };

            var totalCount = await filteredDocuments.CountAsync();

            return new PagedResultDto<GetDocumentForViewDto>(
                totalCount,
                await documents.ToListAsync()
            );
        }
        
        public override async Task<DocumentDto> UpdateAsync(DocumentDto input)
        {
            return await base.UpdateAsync(input);
        }

        public async Task<GetDocumentForViewDto> GetDocumentForView(long id)
        {
            var document = await _documentRepository.GetAsync(id);

            var output = new GetDocumentForViewDto { Document = ObjectMapper.Map<DocumentDto>(document) };

            return output;
        }

        public async Task<GetDocumentForEditOutput> GetDocumentForEdit(EntityDto<long> input)
        {
            var document = await _documentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetDocumentForEditOutput { Document = ObjectMapper.Map<CreateDocumentDto>(document) };

            return output;
        }

   
    }
}