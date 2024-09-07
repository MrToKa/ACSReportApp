using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            var assembly = await this.repo.All<PartAssembly>()
                .FirstOrDefaultAsync(pa => pa.Name == partAssembly.Name && pa.Manufacturer == partAssembly.Manufacturer && pa.IsDeleted == true);

            if (assembly != null)
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
                .Include(pa => pa.PartAssemblyParts)
                .Select(pa => new PartAssemblyModel
                {
                    Id = pa.Id,
                    PartAssemblyType = pa.PartAssemblyType,
                    Name = pa.Name,
                    Manufacturer = pa.Manufacturer,
                    Description = pa.Description,
                    Remarks = pa.Remarks,
                    Parts = pa.PartAssemblyParts.Select(p => new PartServiceModel
                    {
                        PartType = p.Part.PartType,
                        OrderNumber = p.Part.OrderNumber,
                        Manufacturer = p.Part.Manufacturer,
                        Description = p.Part.Description,
                        Picture = p.Part.Picture,
                        Remarks = p.Part.Remarks,
                        Quantity = p.Quantity,
                        Height = p.Part.Height,
                        Width = p.Part.Width,
                        Length = p.Part.Length,
                        Weight = p.Part.Weight,
                        Diameter = p.Part.Diameter,
                        Measurement = p.Part.Measurement.ToString(),
                        Id = p.Part.Id,

                    }).ToList()
                }).ToListAsync();
        }


        public async Task<PartAssemblyModel> GetPartAssemblyAsync(int partAssemblyId)
        {
            var partAssembly = await this.repo.All<PartAssembly>()
                .Where(pa => pa.Id == partAssemblyId)
                .Include(pa => pa.PartAssemblyParts)
                .Select(pa => new PartAssemblyModel
                {
                    Id = pa.Id,
                    PartAssemblyType = pa.PartAssemblyType,
                    Name = pa.Name,
                    Manufacturer = pa.Manufacturer,
                    Description = pa.Description,
                    Picture = pa.Picture,
                    Remarks = pa.Remarks,
                    Parts = pa.PartAssemblyParts.Select(p => new PartServiceModel
                    {
                        PartType = p.Part.PartType,
                        OrderNumber = p.Part.OrderNumber,
                        Manufacturer = p.Part.Manufacturer,
                        Description = p.Part.Description,
                        Picture = p.Part.Picture,
                        Remarks = p.Part.Remarks,
                        Quantity = p.Quantity,
                        Height = p.Part.Height,
                        Width = p.Part.Width,
                        Length = p.Part.Length,
                        Weight = p.Part.Weight,
                        Diameter = p.Part.Diameter,
                        Measurement = p.Part.Measurement.ToString(),
                        Id = p.Part.Id,

                    }).ToList()
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
                .Include(pa => pa.PartAssemblyParts)
                .FirstOrDefaultAsync(pa => pa.Id == partAssemblyId);

            if (assemblyToUpdate != null)
            {
                assemblyToUpdate.PartAssemblyType = partAssembly.PartAssemblyType;
                assemblyToUpdate.Name = partAssembly.Name;
                assemblyToUpdate.Description = partAssembly.Description;
                assemblyToUpdate.Manufacturer = partAssembly.Manufacturer;
                assemblyToUpdate.Picture = partAssembly.Picture;
                assemblyToUpdate.Remarks = partAssembly.Remarks;

                foreach (var part in partAssembly.Parts)
                {
                    await PartAssemblyPartService.UpdatePartQuantityAsync(assemblyToUpdate.Id, part.Id, part.Quantity);
                }

                if (assemblyToUpdate.PartAssemblyParts.Count > partAssembly.Parts.Count)
                {
                    var partsToRemove = assemblyToUpdate.PartAssemblyParts
                        .Where(p => !partAssembly.Parts.Any(pa => pa.Id == p.PartId))
                        .ToList();

                    foreach (var part in partsToRemove)
                    {
                        await PartAssemblyPartService.RemovePartFromAssemblyAsync(assemblyToUpdate.Id, part.PartId);
                    }
                }

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
                .FirstOrDefaultAsync(pa => pa.Name == partAssembly.Name && pa.Manufacturer == partAssembly.Manufacturer && pa.PartAssemblyType == partAssembly.PartAssemblyType);

            if (assemblyToRestore != null)
            {
                assemblyToRestore.IsDeleted = false;
                assemblyToRestore.DeletedOn = null;
                assemblyToRestore.PartAssemblyParts.Clear();
                assemblyToRestore.Name = partAssembly.Name;
                assemblyToRestore.Description = partAssembly.Description;
                assemblyToRestore.Manufacturer = partAssembly.Manufacturer;
                assemblyToRestore.Picture = partAssembly.Picture;
                assemblyToRestore.Remarks = partAssembly.Remarks;
                assemblyToRestore.CreatedOn = DateTime.UtcNow;
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
                Manufacturer = assemblyToRestore.Manufacturer,
                Remarks = assemblyToRestore.Remarks,
                Parts = new List<PartServiceModel>()
            };
        }

        public async Task AddPartToAssemblyAsync(int partAssemblyId, PartAssemblyPartModel part)
        {
            var assembly = await this.repo.All<PartAssembly>()
                .Include(pa => pa.PartAssemblyParts)
                .FirstOrDefaultAsync(pa => pa.Id == partAssemblyId)
                ?? throw new InvalidOperationException("Assembly not found");

            if (!assembly.PartAssemblyParts.Any(p => p.PartId == part.PartId))
            {
                assembly.PartAssemblyParts.Add(new PartAssemblyPart
                {
                    PartId = part.PartId,
                    Quantity = part.Quantity
                });
            }

            await this.repo.SaveChangesAsync();
        }
    }
}
