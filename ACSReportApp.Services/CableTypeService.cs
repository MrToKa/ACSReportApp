using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class CableTypeService : ICableTypeService
    {
        private readonly IACSReportAppDbRepository repo;

        public CableTypeService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public async Task<CableTypeServiceModel> CreateCableTypeAsync(CableTypeServiceModel cableType)
        {
            var newCableType = new CableType()
            {                
                Type = cableType.Type,
                Description = cableType.Description,
                Purpose = cableType.Purpose,
                Voltage = cableType.Voltage,
                CrossSection = cableType.CrossSection,
                Diameter = cableType.Diameter,
                Shield = cableType.Shield,
                BendingRadius = cableType.BendingRadius,
                WeightPerKm = cableType.WeightPerKm,
                Manufacturer = cableType.Manufacturer,
                PartNumber = cableType.PartNumber
            };

            await this.repo.AddAsync(newCableType);
            await this.repo.SaveChangesAsync();

            return new CableTypeServiceModel()
            {
                Id = cableType.Id,
                Type = newCableType.Type,
                Description = newCableType.Description,
                Purpose = newCableType.Purpose,
                Voltage = newCableType.Voltage,
                CrossSection = newCableType.CrossSection,
                Diameter = newCableType.Diameter,
                Shield = newCableType.Shield,
                BendingRadius = newCableType.BendingRadius,
                WeightPerKm = newCableType.WeightPerKm,
                Manufacturer = newCableType.Manufacturer,
                PartNumber = newCableType.PartNumber
            };
        }

        public async Task<CableTypeServiceModel> DeleteCableTypeAsync(int cableTypeId)
        {
            var cableTypeToDelete = await this.repo.All<CableType>()
                .FirstOrDefaultAsync(c => c.Id == cableTypeId);

            if (cableTypeToDelete != null)
            {
                cableTypeToDelete.IsDeleted = true;
                await this.repo.SaveChangesAsync();
            }

            return await Task.FromResult(new CableTypeServiceModel());
        }

        public async Task<List<CableTypeServiceModel>> GetCablesTypesAsync()
        {
            var cablesTypesList = await this.repo.All<CableType>()
                .Where(c => !c.IsDeleted)
                .Select(c => new CableTypeServiceModel()
                {
                    Id = c.Id,
                    Type = c.Type,
                    Description = c.Description,
                    Purpose = c.Purpose,
                    Voltage = c.Voltage,
                    CrossSection = c.CrossSection,
                    Diameter = c.Diameter,
                    Shield = c.Shield,
                    BendingRadius = c.BendingRadius,
                    WeightPerKm = c.WeightPerKm,
                    Manufacturer = c.Manufacturer,
                    PartNumber = c.PartNumber
                })
                .OrderBy(c => c.Type)
                .ThenBy(c => c.CrossSection)
                .ToListAsync();

            return cablesTypesList;
        }


        public async Task<CableTypeServiceModel> GetCableTypeAsync(int cableTypeId)
        {
            var cableType = await this.repo.All<CableType>()
                .FirstOrDefaultAsync(c => c.Id == cableTypeId);

            if (cableType == null)
            {
                throw new ArgumentException("Cable type not found.");
            }

            return new CableTypeServiceModel()
            {
                Id = cableType.Id,
                Type = cableType.Type,
                Description = cableType.Description,
                Purpose = cableType.Purpose,
                Voltage = cableType.Voltage,
                CrossSection = cableType.CrossSection,
                Diameter = cableType.Diameter,
                Shield = cableType.Shield,
                BendingRadius = cableType.BendingRadius,
                WeightPerKm = cableType.WeightPerKm,
                Manufacturer = cableType.Manufacturer,
                PartNumber = cableType.PartNumber
            };
        }

        public Task<List<CableTypeServiceModel>> GetCableTypesByProjectIdAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<CableTypeServiceModel> UpdateCableTypeAsync(CableTypeServiceModel cableType, int cableTypeId)
        {
            var cableTypeToUpdate = await this.repo.All<CableType>()
                .FirstOrDefaultAsync(c => c.Id == cableTypeId);

            if (cableTypeToUpdate == null)
                {
                throw new ArgumentException("Cable type not found.");
            }

            cableTypeToUpdate.Type = cableType.Type;
            cableTypeToUpdate.Description = cableType.Description;
            cableTypeToUpdate.Purpose = cableType.Purpose;
            cableTypeToUpdate.Voltage = cableType.Voltage;
            cableTypeToUpdate.CrossSection = cableType.CrossSection;
            cableTypeToUpdate.Diameter = cableType.Diameter;
            cableTypeToUpdate.Shield = cableType.Shield;
            cableTypeToUpdate.BendingRadius = cableType.BendingRadius;
            cableTypeToUpdate.WeightPerKm = cableType.WeightPerKm;
            cableTypeToUpdate.Manufacturer = cableType.Manufacturer;
            cableTypeToUpdate.PartNumber = cableType.PartNumber;

            await this.repo.SaveChangesAsync();

            return new CableTypeServiceModel()
            {
                Id = cableTypeToUpdate.Id,
                Type = cableTypeToUpdate.Type,
                Description = cableTypeToUpdate.Description,
                Purpose = cableTypeToUpdate.Purpose,
                Voltage = cableTypeToUpdate.Voltage,
                CrossSection = cableTypeToUpdate.CrossSection,
                Diameter = cableTypeToUpdate.Diameter,
                Shield = cableTypeToUpdate.Shield,
                BendingRadius = cableTypeToUpdate.BendingRadius,
                WeightPerKm = cableTypeToUpdate.WeightPerKm,
                Manufacturer = cableTypeToUpdate.Manufacturer,
                PartNumber = cableTypeToUpdate.PartNumber
            };
        }
    }
}
