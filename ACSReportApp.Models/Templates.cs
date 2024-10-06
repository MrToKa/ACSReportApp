using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TemplateTag { get; set; }
        public string TemplateType { get; set; }
        public string? TemplateDescription { get; set; }
        public string? TemplatePath { get; set; }
    }
}
