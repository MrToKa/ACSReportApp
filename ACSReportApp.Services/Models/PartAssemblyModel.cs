namespace ACSReportApp.Services.Models
{
    public class PartAssemblyModel
    {
        public PartAssemblyModel()
        {
            Parts = new List<PartServiceModel>();
        }

        public int Id { get; set; }
        public string PartAssemblyType { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string? Picture { get; set; }
        public string? Remarks { get; set; }
        public List<PartServiceModel> Parts { get; set; }
    }
}