using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class Consumer 
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public string Tag { get; set; }

        [Required]
        public string Name { get; set; }

        public string? System { get; set; }

        public string? Location { get; set; }

        public double Power { get; set; }

        public double Current { get; set; }

        public double Voltage { get; set; }

        public double CosPhi { get; set; }

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
