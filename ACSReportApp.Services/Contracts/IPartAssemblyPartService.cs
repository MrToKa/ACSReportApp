using ACSReportApp.Models;
using ACSReportApp.Services.Models;

namespace ACSReportApp.Services.Contracts
{
    public interface IPartAssemblyPartService
    {
        Task AddPartToAssembly(int partAssemblyId, int partId, int quantity);
        Task RemovePartFromAssembly(int partAssemblyId, int partId);
        Task UpdatePartQuantity(int partAssemblyId, int partId, int quantity);
        Task<List<PartAssemblyPart>> GetPartsInAssembly(int partAssemblyId);
        Task<PartAssemblyPart> CreateAssemblyPart(int partAssemblyId, int partId ,int quantity);
    }
}
