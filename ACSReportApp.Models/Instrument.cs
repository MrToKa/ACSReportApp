using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public string Tag { get; set; }

        public string Name { get; set; }

        public string? System { get; set; }

        public string? Location { get; set; }

        public string? Manufacturer { get; set; }

        public string? PartNumber { get; set; }

        public string? Description { get; set; }

        public string? SignalType { get; set; }

        public double? AuxPower { get; set; }

        public double? Voltage { get; set; }

        public string? Remarks { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedOn { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ModifiedBy { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
