using ACSReportApp.Services.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ACSReportApp.Services.Contracts
{
    public interface ICableTypeService
    {
        Task<CableTypeServiceModel> GetCableTypeAsync(int cableTypeId);

        Task<List<CableTypeServiceModel>> GetCablesTypesAsync();

        Task<CableTypeServiceModel> CreateCableTypeAsync(CableTypeServiceModel cableType);

        Task<CableTypeServiceModel> UpdateCableTypeAsync(CableTypeServiceModel cableType, int cableTypeId);

        Task DeleteCableTypeAsync(int cableTypeId);

        Task<List<CableTypeServiceModel>> GetCableTypesByProjectIdAsync(Guid projectId);

        Task UploadFromFileAsync(IBrowserFile file);

        Task<CableTypeServiceModel> RestoreCableTypeAsync(CableTypeServiceModel cableType);
    }
}
