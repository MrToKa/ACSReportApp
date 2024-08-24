using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class CableTray
    {
        public CableTray()
        {
            PartAssemblies = new List<PartAssembly>();
            Parts = new List<Part>();
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public string Tag { get; set; }

        public string? Purpose { get; set; }
        
        public double Height { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double Weight { get; set; }

        public string Manufacturer { get; set; }

        public string Type { get; set; }

        public string PartNumber { get; set; }

        public virtual List<PartAssembly> PartAssemblies { get; set; }

        public virtual List<Part> Parts { get; set; }
    }
}
