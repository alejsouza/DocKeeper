
using System;
using Abp.Application.Services.Dto;

namespace Ranallo.DocKeeper.Documents.Dto
{
    public class DocumentDto : EntityDto<long>
    {
		public string Name { get; set; }

		public string Location { get; set; }

		public string Description { get; set; }

		public int FileId { get; set; }



    }
}