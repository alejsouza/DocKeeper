
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Ranallo.DocKeeper.Documents;

namespace Ranallo.DocKeeper.Documents.Dto
{
    public class CreateDocumentDto : EntityDto<long?>
    {

		[Required]
		[StringLength(DocumentConsts.MaxNameLength, MinimumLength = DocumentConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[Required]
		[StringLength(DocumentConsts.MaxUbicacionLength, MinimumLength = DocumentConsts.MinUbicacionLength)]
		public string Location { get; set; }
		
		
		[StringLength(DocumentConsts.MaxDescripcionLength, MinimumLength = DocumentConsts.MinDescripcionLength)]
		public string Description { get; set; }
		
		
		public int FileId { get; set; }
		
		

    }
}