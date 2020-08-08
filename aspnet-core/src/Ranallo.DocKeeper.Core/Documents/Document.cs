using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Ranallo.DocKeeper.Documents
{
    [Table("Documents")]
    public class Document : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(DocumentConsts.MaxNameLength, MinimumLength = DocumentConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(DocumentConsts.MaxUbicacionLength, MinimumLength = DocumentConsts.MinUbicacionLength)]
        public virtual string Location { get; set; }

        [StringLength(DocumentConsts.MaxDescripcionLength, MinimumLength = DocumentConsts.MinDescripcionLength)]
        public virtual string Description { get; set; }

        public virtual int FileId { get; set; }


    }
}