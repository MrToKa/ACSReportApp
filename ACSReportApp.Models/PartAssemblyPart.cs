using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class PartAssemblyPart
    {
        [Key]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!;

        [Key]
        public int? PartAssemblyId { get; set; }

        [ForeignKey(nameof(PartAssemblyId))]
        public PartAssembly? PartAssembly { get; set; }

        public int Quantity { get; set; }
    }
}
