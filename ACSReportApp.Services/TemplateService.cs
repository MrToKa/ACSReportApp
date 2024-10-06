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
                    TemplateType = t.TemplateType,
                    TemplatePath = t.TemplatePath,
                    TemplateTag = t.TemplateTag,
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
                    TemplateType = t.TemplateType,
                    TemplateTag = t.TemplateTag,
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
                templateToUpdate.Name = template.Name;
                templateToUpdate.TemplateType = template.TemplateType;
                if (templateToUpdate.TemplateTag != template.TemplateTag)
                {
                    string uploadFolder = Path.Combine(UploadPath, template.TemplateTag);

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string uniqueFileName = template.TemplateType + ".xlsx";
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

        public async Task<TemplateServiceModel> UploadTemplateAsync(IBrowserFile file, string templateType, string templateTag, string templateDesc)
        {
            string uploadFolder = Path.Combine(UploadPath, templateTag);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string uniqueFileName = templateType + ".xlsx";
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }

            var template = new Template()
            {
                Name = uniqueFileName,
                TemplateType = templateType,
                TemplateTag = templateTag,
                TemplatePath = filePath,
                TemplateDescription = templateDesc
            };

            await this.repo.AddAsync(template);
            await this.repo.SaveChangesAsync();

            return new TemplateServiceModel()
            {
                Id = template.Id.ToString(),
                Name = template.Name,
                TemplateType = template.TemplateType,
                TemplatePath = template.TemplatePath,
                TemplateTag = template.TemplateTag,
                TemplateDescription = template.TemplateDescription
            };
        }
    }
}
