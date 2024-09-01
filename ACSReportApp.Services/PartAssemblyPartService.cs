using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class PartAssemblyPartService : IPartAssemblyPartService
    {
        private readonly IACSReportAppDbRepository repo;

        public PartAssemblyPartService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddPartToAssembly(int partAssemblyId, int partId, int quantity)
        {
            var partAssemblyPart = new PartAssemblyPart
            {
                PartAssemblyId = partAssemblyId,
                PartId = partId,
                Quantity = quantity
            };

            await repo.AddAsync(partAssemblyPart);
            await repo.SaveChangesAsync();
        }

        public async Task RemovePartFromAssembly(int partAssemblyId, int partId)
        {
            var partAssemblyPart = await repo.All<PartAssemblyPart>()
                .FirstOrDefaultAsync(pap => pap.PartAssemblyId == partAssemblyId && pap.PartId == partId);

            if (partAssemblyPart != null)
            {
                repo.Delete(partAssemblyPart);
                await repo.SaveChangesAsync();
            }
        }

        public async Task UpdatePartQuantity(int partAssemblyId, int partId, int quantity)
        {
            var partAssemblyPart = await repo.All<PartAssemblyPart>()
                .FirstOrDefaultAsync(pap => pap.PartAssemblyId == partAssemblyId && pap.PartId == partId);

            if (partAssemblyPart != null)
            {
                partAssemblyPart.Quantity = quantity;
                await repo.SaveChangesAsync();
            }
        }
    }
}
