using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IACSReportAppDbRepository repo;
        //private const string UploadPath = "C:\\Users\\todor.chankov\\source\\repos\\ACSReportApp\\ACSReportApp.MudBlazorUI\\wwwroot\\";
        private const string UploadPath = "C:\\Users\\TOKA\\source\\repos\\ACSReportApp\\ACSReportApp.MudBlazorUI\\wwwroot\\Templates\\";

        public TemplateService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }
        public async Task<List<TemplateServiceModel>> GetTemplatesAsync()
        {
            return await this.repo.All<Template>()
                .Select(t => new TemplateServiceModel()
                {
                    Id = t.Id.ToString(),
                    Name = t.Name,
                    TemplateName = t.TemplateName,
                    TemplatePath = t.TemplatePath,
                    TemplateType = t.TemplateType,
                    TemplateDescription = t.TemplateDescription
                })
                .ToListAsync();
        }

        public async Task<TemplateServiceModel?> GetTemplateByIdAsync(string id)
        {
            return await this.repo.All<Template>()
                .Where(t => t.Id.ToString() == id)
                .Select(t => new TemplateServiceModel()
                {
                    Id = t.Id.ToString(),
                    Name = t.Name,
                    TemplateName = t.TemplateName,
                    TemplateType = t.TemplateType,
                    TemplateDescription = t.TemplateDescription,
                    TemplatePath = t.TemplatePath,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TemplateServiceModel> UpdateTemplateAsync(TemplateServiceModel template)
        {
            var templateToUpdate = await this.repo.All<Template>().FirstOrDefaultAsync(t => t.Id == Guid.Parse(template.Id));

            if (templateToUpdate != null)
            {
                templateToUpdate.TemplateName = template.TemplateName;
                if (templateToUpdate.TemplateType != template.TemplateType)
                {
                    string uploadFolder = Path.Combine(UploadPath, template.TemplateType);

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string uniqueFileName = template.TemplateName + ".xlsx";
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    File.Move(templateToUpdate.TemplatePath, filePath);

                    templateToUpdate.TemplatePath = filePath;
                }
                templateToUpdate.TemplateDescription = template.TemplateDescription;

                await this.repo.SaveChangesAsync();
            }

            return template;
        }

        public async Task DeleteTemplateAsync(string id)
        {
            var template = await this.repo.All<Template>().FirstOrDefaultAsync(t => t.Id.ToString() == id);
            if (template != null)
            {
                if (File.Exists(template.TemplatePath))
                {
                    File.Delete(template.TemplatePath);
                }
                await this.repo.DeleteAsync<Template>(template.Id);
                await this.repo.SaveChangesAsync();
            }

        }

        public async Task<TemplateServiceModel> UploadTemplateAsync(IBrowserFile file, string templateName, string templateType, string templateDesc)
        {
            string uploadFolder = Path.Combine(UploadPath, templateType);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string fileName = templateName + ".xlsx";
            string filePath = Path.Combine(uploadFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }

            var template = new Template()
            {
                Name = fileName,
                TemplateName = templateName,
                TemplateType = templateType,
                TemplatePath = filePath,
                TemplateDescription = templateDesc
            };

            await this.repo.AddAsync(template);
            await this.repo.SaveChangesAsync();

            return new TemplateServiceModel()
            {
                Id = template.Id.ToString(),
                Name = template.Name,
                TemplateName = template.TemplateName,
                TemplatePath = template.TemplatePath,
                TemplateType = template.TemplateType,
                TemplateDescription = template.TemplateDescription
            };
        }
    }
}
