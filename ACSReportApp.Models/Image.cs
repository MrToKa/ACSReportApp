using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageTag { get; set; }
        public string ImageType { get; set; }
        public string? ImageDescription { get; set; }
        public string? ImagePath { get; set; }
        public CableTray CableTray { get; set; }

        [ForeignKey(nameof(CableTray))]
        public int? CableTrayId { get; set; }
    }
}
