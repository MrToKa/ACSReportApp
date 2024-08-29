using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ACSReportApp.Services.Contracts
{
    public interface IImageService
    {
        Task<ImageServiceModel> UploadImageAsync(IBrowserFile file, string imageType, string imageTag);
        Task<IEnumerable<ImageServiceModel>> GetImagesAsync(string imageType);
        Task<ImageServiceModel> UpdateImageAsync(ImageServiceModel image);
        Task DeleteImageAsync(string imageTag);
        Task<ImageServiceModel> GetImageAsync(string imageTag);
        Task<IEnumerable<ImageServiceModel>> GetAllImagesAsync();
        Task<IEnumerable<string>> GetImagesTypesAsync(string imageType);
    }
}
