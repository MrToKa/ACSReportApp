using ACSReportApp.Models;
using ACSReportApp.Services.Models;

namespace ACSReportApp.Services.Contracts
{
    public interface IPartAssemblyPartService
    {
        Task AddPartToAssemblyAsync(int partAssemblyId, int partId, int quantity);
        Task RemovePartFromAssemblyAsync(int partAssemblyId, int partId);
        Task UpdatePartQuantityAsync(int partAssemblyId, int partId, int quantity);
        Task<List<PartAssemblyPartModel>> GetPartsInAssemblyAsync(int partAssemblyId);
        Task<PartAssemblyPart> CreateAssemblyPartAsync(int partAssemblyId, int partId ,int quantity);
    }
}
