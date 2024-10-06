using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ACSReportApp.Services.Contracts
{
    public interface ITemplateService
    {
        Task<List<TemplateServiceModel>> GetTemplatesAsync();
        Task<TemplateServiceModel?> GetTemplateByIdAsync(string id);
        Task<TemplateServiceModel> UpdateTemplateAsync(TemplateServiceModel template);
        Task DeleteTemplateAsync(string id);
        Task<TemplateServiceModel> UploadTemplateAsync(IBrowserFile file, string templateName, string templateType, string templateDesc);
    }
}
