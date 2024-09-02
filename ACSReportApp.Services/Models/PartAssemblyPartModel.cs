namespace ACSReportApp.Services.Models
{
    public class PartAssemblyPartModel
    {
        public int Id { get; set; }
        public int? PartAssemblyId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}
