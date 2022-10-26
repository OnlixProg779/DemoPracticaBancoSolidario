using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSolidario.Common.CommonExtendEntity
{
    public abstract class BaseDomainModel
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        [Required]
        public bool? Editable { get; set; }
        [Required]
        public bool? Borrable { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Required]
        public bool? ShowToUserMed { get; set; }

        [NotMapped]
        public InfoResponseVm Response { get; set; }

    }
}
