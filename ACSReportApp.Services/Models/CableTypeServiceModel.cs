using ACSReportApp.Models.Enums;

namespace ACSReportApp.Services.Models
{
    public class CableTypeServiceModel 
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public string Purpose { get; set; } = null!;

        public int? Voltage { get; set; }

        public int? Pairs { get; set; }

        public int Conductors { get; set; }

        public CableDelimiter? Delimiter { get; set; }

        public double CrossSection { get; set; }

        public CableDelimiter? GroundingDelimiter { get; set; }

        public int? PEConductors { get; set; }

        public CableDelimiter? PEDelimiter { get; set; }

        public double? PECrossSection { get; set; }

        public double? Diameter { get; set; }

        public bool Shield { get; set; }

        public double? BendingRadius { get; set; }

        public double WeightPerKm { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string? PartNumber { get; set; }
    }
}