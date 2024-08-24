namespace ACSReportApp.Models
{
    public class CableType
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public string Purpose { get; set; } = null!;

        public int? Voltage { get; set; }

        public string CrossSection { get; set; } = null!;

        public double? Diameter { get; set; }

        public bool Shield { get; set; }

        public double? BendingRadius { get; set; }

        public double WeightPerKm { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string? PartNumber { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}