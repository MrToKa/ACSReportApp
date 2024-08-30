using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ACSReportApp.Services.Contracts
{
    public interface IPartService
    {
        Task<List<PartServiceModel>> GetPartsAsync(string partType);
        Task<PartServiceModel> GetPartAsync(string partNumber);
        Task<PartServiceModel> GetPartAsync(int id);
        Task<PartServiceModel> CreatePartAsync(PartServiceModel part);
        Task<PartServiceModel> UpdatePartAsync(PartServiceModel part);
        Task DeletePartAsync(int id);
        Task AddPartsFromFileAsync(Stream stream);
        Task<List<string>> GetPartsTypesAsync();
        Task<List<string>> GetPartsNumbersForSearchAsync();
        Task<List<string>> GetMeasurementAsync();
        Task AssignImageAsync(int partId, string imageTag);
        Task UploadFromFileAsync(IBrowserFile file);
        Task<PartServiceModel> RestorePart(PartServiceModel part);
    }
}
