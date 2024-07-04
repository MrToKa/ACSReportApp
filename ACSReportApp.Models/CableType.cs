namespace ACSReportApp.Models
{
    public class CableType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Type { get; set; }

        public string Voltage { get; set; }

        public int Conductors { get; set; }

        public int? Pairs { get; set; }

        public double CrossSection { get; set; }

        public double Diameter { get; set; }

        public bool IsVFDType { get; set; }

        public double? BendingRadius { get; set; }

        public double WeightPerKm { get; set; }

        public string Manufacturer { get; set; }

        public string PartNumber { get; set; }
    }
}