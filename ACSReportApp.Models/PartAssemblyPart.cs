using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class PartAssemblyPart
    {
        [Key]
        public int Id { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; } = null!;

        public int PartAssemblyId { get; set; }
        public PartAssembly PartAssembly { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
