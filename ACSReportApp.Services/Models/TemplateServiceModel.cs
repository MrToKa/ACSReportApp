namespace ACSReportApp.Services.Models
{
    public class TemplateServiceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TemplateTag { get; set; }
        public string TemplateType { get; set; }
        public string? TemplateDescription { get; set; }
        public string? TemplatePath { get; set; }
    }
}
