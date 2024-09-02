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
        private readonly IPartAssemblyPartService PartAssemblyPartService;

        public PartAssemblyService(IACSReportAppDbRepository repo,
            IPartAssemblyPartService PartAssemblyPartService)
        {
            this.repo = repo;
            this.PartAssemblyPartService = PartAssemblyPartService;

        }
        public async Task<PartAssemblyModel> CreatePartAssemblyAsync(PartAssemblyModel partAssembly)
        {
            ArgumentNullException.ThrowIfNull(partAssembly);

            bool assemblyExists = await this.repo.All<PartAssembly>()
                .AnyAsync(pa => pa.Name == partAssembly.Name && pa.Manufacturer == partAssembly.Manufacturer && pa.IsDeleted == true);

            if (assemblyExists)
            {
                return await this.RestoreAssemblyAsync(partAssembly);
            }

            var partAssemblyEntity = new PartAssembly
            {
                PartAssemblyType = partAssembly.PartAssemblyType,
                Name = partAssembly.Name,
                Description = partAssembly.Description,
                Manufacturer = partAssembly.Manufacturer,
                Picture = partAssembly.Picture,
                Remarks = partAssembly.Remarks,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            await repo.AddAsync(partAssemblyEntity);
            await repo.SaveChangesAsync();

            return new PartAssemblyModel
            {
                Id = partAssemblyEntity.Id,
                PartAssemblyType = partAssemblyEntity.PartAssemblyType,
                Name = partAssemblyEntity.Name,
                Description = partAssemblyEntity.Description,
                Manufacturer = partAssemblyEntity.Manufacturer,
            };

        }

        public async Task DeletePartAssemblyAsync(int partAssemblyId)
        {
            var assemblyToDelete = await repo.All<PartAssembly>()
                .FirstOrDefaultAsync(pa => pa.Id == partAssemblyId);

            if (assemblyToDelete != null)
            {
                assemblyToDelete.IsDeleted = true;
                assemblyToDelete.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Assembly not found");
            }

        }

        public async Task<List<PartAssemblyModel>> GetPartAssembliesAsync()
        {
            return await this.repo.All<PartAssembly>()
                .Where(pa => pa.IsDeleted == false)
                .Select(pa => new PartAssemblyModel
                {
                    Id = pa.Id,
                    PartAssemblyType = pa.PartAssemblyType,
                    Name = pa.Name,
                    Description = pa.Description,
                }).ToListAsync();
        }


        public async Task<PartAssemblyModel> GetPartAssemblyAsync(int partAssemblyId)
        {
            var partAssembly = await this.repo.All<PartAssembly>()
                .Where(pa => pa.Id == partAssemblyId)
                .Select(pa => new PartAssemblyModel
                {
                    Id = pa.Id,
                    PartAssemblyType = pa.PartAssemblyType,
                    Name = pa.Name,
                    Description = pa.Description,
                }).FirstOrDefaultAsync();

            if (partAssembly == null)
            {
                throw new InvalidOperationException("Assembly not found");
            }

            return partAssembly;
        }

        public async Task<PartAssemblyModel> UpdatePartAssemblyAsync(PartAssemblyModel partAssembly, int partAssemblyId)
        {
            var assemblyToUpdate = await this.repo.All<PartAssembly>()
                .FirstOrDefaultAsync(pa => pa.Id == partAssemblyId);

            if (assemblyToUpdate != null)
            {
                assemblyToUpdate.PartAssemblyType = partAssembly.PartAssemblyType;
                assemblyToUpdate.Name = partAssembly.Name;
                assemblyToUpdate.Description = partAssembly.Description;
                assemblyToUpdate.Manufacturer = partAssembly.Manufacturer;
                assemblyToUpdate.Picture = partAssembly.Picture;
                assemblyToUpdate.Remarks = partAssembly.Remarks;
                await this.repo.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Assembly not found");
            }

            return new PartAssemblyModel
            {
                PartAssemblyType = assemblyToUpdate.PartAssemblyType,
                Name = assemblyToUpdate.Name,
                Description = assemblyToUpdate.Description,
                Manufacturer = assemblyToUpdate.Manufacturer
            };
        }

        public async Task<PartAssemblyModel> RestoreAssemblyAsync(PartAssemblyModel partAssembly)
        {
            var assemblyToRestore = await this.repo.All<PartAssembly>()
                .FirstOrDefaultAsync(pa => pa.Id == partAssembly.Id);

            if (assemblyToRestore != null)
            {
                assemblyToRestore.IsDeleted = false;
                assemblyToRestore.DeletedOn = null;
                await this.repo.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Assembly not found");
            }

            return new PartAssemblyModel
            {
                PartAssemblyType = assemblyToRestore.PartAssemblyType,
                Name = assemblyToRestore.Name,
                Description = assemblyToRestore.Description,
                Manufacturer = assemblyToRestore.Manufacturer
            };
        }

        public async Task AddPartsToAssemblyAsync(int partAssemblyId, List<PartAssemblyPartModel> parts)
        {
            var assembly = await this.repo.All<PartAssembly>()
                .FirstOrDefaultAsync(pa => pa.Id == partAssemblyId) ?? throw new InvalidOperationException("Assembly not found");

            List<PartAssemblyPart> partsToAdd = [];

            foreach (var part in parts)
            {
                var createdPart = await PartAssemblyPartService.CreateAssemblyPart(partAssemblyId, part.PartId, part.Quantity);
            }

            await this.repo.SaveChangesAsync();
        }
    }
}
