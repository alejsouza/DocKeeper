using Abp.Application.Services.Dto;
using System;

namespace Ranallo.DocKeeper.Documents.Dto
{
    public class PagedDocumentResultRequestDto : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public string LocationFilter { get; set; }

		public string DescriptionFilter { get; set; }

    }
}