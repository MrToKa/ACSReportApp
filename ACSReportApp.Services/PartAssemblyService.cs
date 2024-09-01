using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class PartAssemblyService : IPartAssemblyService
    {
        private readonly IACSReportAppDbRepository repo;

        public PartAssemblyService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }
        public Task<PartAssemblyModel> CreatePartAssemblyAsync(PartAssemblyModel partAssembly)
        {
            throw new NotImplementedException();
        }

        public Task<PartAssemblyModel> DeletePartAssemblyAsync(int partAssemblyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PartAssemblyModel>> GetPartAssembliesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<PartAssemblyModel>> GetPartAssembliesByProjectIdAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task<PartAssemblyModel> GetPartAssemblyAsync(int partAssemblyId)
        {
            throw new NotImplementedException();
        }

        public Task<PartAssemblyModel> UpdatePartAssemblyAsync(PartAssemblyModel partAssembly, int partAssemblyId)
        {
            throw new NotImplementedException();
        }       

    }
}
