using ACSReportApp.Services.Models;

namespace ACSReportApp.Services.Contracts
{
    public interface IPartAssemblyService
    {
        Task<PartAssemblyModel> GetPartAssemblyAsync(int partAssemblyId);
        Task<List<PartAssemblyModel>> GetPartAssembliesAsync();
        Task<PartAssemblyModel> CreatePartAssemblyAsync(PartAssemblyModel partAssembly);
        Task<PartAssemblyModel> UpdatePartAssemblyAsync(PartAssemblyModel partAssembly, int partAssemblyId);
        Task<PartAssemblyModel> DeletePartAssemblyAsync(int partAssemblyId);
        Task<List<PartAssemblyModel>> GetPartAssembliesByProjectIdAsync(Guid projectId);
    }
}
