using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
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
            PartAssemblyPart? partAssemblyPart = new PartAssemblyPart
            {
                PartAssemblyId = partAssemblyId,
                PartId = partId,
                Quantity = quantity
            };

            await repo.AddAsync(partAssemblyPart);
            await repo.SaveChangesAsync();
        }

        public async Task<PartAssemblyPart> CreateAssemblyPart(int partAssemblyId, int partId, int quantity)
        {
            var existingPart = await repo.All<PartAssemblyPart>()
        .FirstOrDefaultAsync(pap => pap.PartId == partId && pap.PartAssemblyId == partAssemblyId);

            if (existingPart != null)
            {
                existingPart.Quantity += quantity;
                repo.Update(existingPart);
            }
            else
            {
                var newPart = new PartAssemblyPart
                {
                    PartId = partId,
                    PartAssemblyId = partAssemblyId,
                    Quantity = quantity
                };
                await repo.AddAsync(newPart);
                existingPart = newPart;
            }

            await repo.SaveChangesAsync();
            return existingPart;
        }

        public async Task<List<PartAssemblyPart>> GetPartsInAssembly(int partAssemblyId)
        {
            return await repo.All<PartAssemblyPart>()
                .Where(pap => pap.PartAssemblyId == partAssemblyId)
                .Include(pap => pap.Part)
                .ToListAsync();
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
