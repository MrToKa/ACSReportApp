using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class CableService : ICableService
    {
        private readonly IACSReportAppDbRepository repo;

        public CableService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public Task<CableServiceModel> CreateCableAsync(CableServiceModel cable)
        {
            throw new NotImplementedException();
        }

        public async Task<CableServiceModel> DeleteCableAsync(int cableId)
        {
            throw new NotImplementedException();
        }

        public async Task<CableServiceModel> GetCableAsync(int cableId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CableServiceModel>> GetCablesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CableServiceModel>> GetCablesByProjectIdAsync(Guid projectId)
        {
            var cablesForProject = await this.repo.All<Cable>()
                .Where(c => c.ProjectId == projectId)
                .Select(c => new CableServiceModel()
                {
                    Id = c.Id,
                    Revision = c.Revision,
                    IsLastRevision = c.IsLastRevision,
                    ProjectId = c.ProjectId,
                    Tag = c.Tag,
                    CableTypeId = c.CableTypeId,
                    System = c.System,
                    FromLocation = c.FromLocation,
                    FromDevice = c.FromDevice,
                    ToLocation = c.ToLocation,
                    ToDevice = c.ToDevice,
                    Routing = c.Routing,
                    DesignLength = c.DesignLength,
                    InstallLength = c.InstallLength,
                    PullDate = c.PullDate,
                    ConnectedFrom = c.ConnectedFrom,
                    ConnectedTo = c.ConnectedTo,
                    TestedDate = c.TestedDate,
                    Delivery = c.Delivery,
                    Remarks = c.Remarks,
                    IsDeleted = c.IsDeleted,
                    LastModifiedOn = c.LastModifiedOn
                })
                .OrderBy(c => c.Tag)
                .ThenBy(c => c.Revision)
                .ToListAsync();

            var cablesWithoutCableType = cablesForProject.Where(c => c.CableTypeId != null).ToList();

            foreach (var cable in cablesWithoutCableType)
            {
                var cableType = this.repo.All<CableType>()
                    .FirstOrDefault(ct => ct.Id == cable.CableTypeId);

                cable.CableType = new CableTypeServiceModel()
                {

                    BendingRadius = cableType.BendingRadius,                   
                    CrossSection = cableType.CrossSection,
                    Diameter = cableType.Diameter,                    
                    Type = cableType.Type,
                    Id = cableType.Id
                };
            }

            return cablesForProject;
        }

        public async Task<CableServiceModel> UpdateCableAsync(CableServiceModel cable, int cableId)
        {
            throw new NotImplementedException();
        }
    }
}
