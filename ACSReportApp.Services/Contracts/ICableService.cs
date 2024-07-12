using ACSReportApp.Services.Models;

namespace ACSReportApp.Services.Contracts
{
    public interface ICableService
    {
        Task<CableServiceModel> GetCableAsync(int cableId);

        Task<List<CableServiceModel>> GetCablesAsync();

        Task<CableServiceModel> CreateCableAsync(CableServiceModel cable);

        Task<CableServiceModel> UpdateCableAsync(CableServiceModel cable, int cableId);

        Task<CableServiceModel> DeleteCableAsync(int cableId);

        Task<List<CableServiceModel>> GetCablesByProjectIdAsync(Guid projectId);
    }
}
