using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class PartAssembly
    {
        public PartAssembly()
        {
            PartAssemblyParts = new List<PartAssemblyPart>();
        }

        [Key]
        public int Id { get; set; }
        public string PartAssemblyType { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string? Picture { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedOn { get; set; }
        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ModifiedBy { get; set; }
        public string? ApplicationUserId { get; set; }

        public virtual ICollection<PartAssemblyPart> PartAssemblyParts { get; set; }
    }
}
