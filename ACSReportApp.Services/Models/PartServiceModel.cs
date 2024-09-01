namespace ACSReportApp.Services.Models
{
    public class PartServiceModel
    {
        public int Id { get; set; }
        public string PartType { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? Weight { get; set; }
        public double? Diameter { get; set; }
        public string Description { get; set; } = null!;
        public string? Measurement { get; set; }
        public string? Picture { get; set; }
        public string? Remarks { get; set; }
        public int Quantity { get; set; }
    }

}
