using AutoMapper;

namespace Ranallo.DocKeeper.Documents.Dto
{
    public class DocumentMapProfile : Profile
    {
        public DocumentMapProfile()
        {
            CreateMap<DocumentDto, Document>();
            CreateMap<DocumentDto, Document>()
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateDocumentDto, Document>();
            CreateMap<Document, DocumentDto>();
        }
    }
}