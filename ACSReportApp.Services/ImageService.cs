using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class ImageService : IImageService
    {
        private readonly IACSReportAppDbRepository repo;
        //private const string UploadPath = "C:\\Users\\todor.chankov\\source\\repos\\ACSReportApp\\ACSReportApp.MudBlazorUI\\wwwroot\\";
        private const string UploadPath = "C:\\Users\\TOKA\\source\\repos\\ACSReportApp\\ACSReportApp.MudBlazorUI\\wwwroot\\";

        public ImageService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public async Task DeleteImageAsync(string imageTag)
        {
            var image = await GetImageAsync(imageTag);
            if (image != null)
            {                
                await this.repo.DeleteAsync<Image>(image.Id);
                await this.repo.SaveChangesAsync();
            }
        }

        public async Task<ImageServiceModel> GetImageAsync(string imageTag)
        {
            var image = await this.repo.All<Image>()
                .Where(i => i.ImageTag == imageTag)
                .Select(i => new ImageServiceModel()
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    ImageType = i.ImageType,
                    ImageTag = i.ImageTag,
                    ImagePath = i.ImagePath,
                    CableTrayId = i.CableTrayId,
                })
                .FirstOrDefaultAsync();

            return image;
        }

        public async Task<IEnumerable<ImageServiceModel>> GetImagesAsync(string imageType)
        {
            List<ImageServiceModel>? images = await this.repo.All<Image>()
                .Where(i => i.ImageType == imageType)
                .Select(i => new ImageServiceModel()
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    ImageType = i.ImageType,
                    ImageTag = i.ImageTag,
                    ImagePath = i.ImagePath,
                    CableTrayId = i.CableTrayId,
                })
                .ToListAsync();

            return images;
        }

        public async Task<ImageServiceModel> UpdateImageAsync(ImageServiceModel image)
        {
            var imageToUpdate = await this.repo.All<Image>()
                .FirstOrDefaultAsync(i => i.Id.ToString() == image.Id);

            if (imageToUpdate != null)
            {
                imageToUpdate.ImageType = image.ImageType;
                imageToUpdate.ImageTag = image.ImageTag;
                imageToUpdate.ImagePath = image.ImagePath;
                imageToUpdate.CableTrayId = image.CableTrayId;

                await this.repo.SaveChangesAsync();
            }

            return image;
        }

        public async Task<ImageServiceModel> UploadImageAsync(IBrowserFile file, string imageType, string imageTag)
        {
            string uploadsFolder = Path.Combine(UploadPath, imageType);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }

            var image = new Image()
            {   
                Name = uniqueFileName,
                ImageType = imageType,
                ImageTag = imageTag,
                ImagePath = filePath,
            };

            await this.repo.AddAsync(image);
            await this.repo.SaveChangesAsync();

            return new ImageServiceModel()
            {
                Id = image.Id.ToString(),
                Name = image.Name,
                ImageType = image.ImageType,
                ImageTag = image.ImageTag,
                ImagePath = image.ImagePath,
                CableTrayId = image.CableTrayId,
            };
        }

        public async Task<IEnumerable<ImageServiceModel>> GetAllImagesAsync()
        {
            return await this.repo.All<Image>()
                .Select(i => new ImageServiceModel()
                {
                    Id = i.Id.ToString(),
                    Name = i.Name,
                    ImageType = i.ImageType,
                    ImageTag = i.ImageTag,
                    ImagePath = i.ImagePath,
                    CableTrayId = i.CableTrayId,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetImagesTypesAsync(string imageType)
        {
            return await this.repo.All<Image>()
                .Where(i => i.ImageType == imageType)
                .Select(i => i.ImageTag)
                .ToListAsync();
        }
    }
}
