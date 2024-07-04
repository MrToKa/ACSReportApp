using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class Support
    {
        public int Id { get; set; }

        public int CableTrayId { get; set; }

        [ForeignKey(nameof(CableTrayId))]
        public CableTray CableTray { get; set; }   

        public string? Description { get; set; }    
        
        public int Count { get; set; }

        public double Distance { get; set; }

        public double Weight { get; set; }

        public string Manufacturer { get; set; }

        public string Type { get; set; }

        public string PartNumber { get; set; }
    }
}
