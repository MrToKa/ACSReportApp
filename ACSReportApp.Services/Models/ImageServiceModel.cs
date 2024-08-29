namespace ACSReportApp.Services.Models
{
    public class ImageServiceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageTag { get; set; }
        public string ImageType { get; set; }
        public string? ImagePath { get; set; }
        public int? CableTrayId { get; set; }
    }
}
