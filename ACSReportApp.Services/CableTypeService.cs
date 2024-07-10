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
                Pairs = cableType.Pairs,
                Conductors = cableType.Conductors,
                Delimiter = cableType.Delimiter,
                CrossSection = cableType.CrossSection,
                GroundingDelimiter = cableType.GroundingDelimiter,
                PEConductors = cableType.PEConductors,
                PEDelimiter = cableType.PEDelimiter,
                PECrossSection = cableType.PECrossSection,
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
                Pairs = newCableType.Pairs,
                Conductors = newCableType.Conductors,
                Delimiter = newCableType.Delimiter,
                CrossSection = newCableType.CrossSection,
                GroundingDelimiter = newCableType.GroundingDelimiter,
                PEConductors = newCableType.PEConductors,
                PEDelimiter = newCableType.PEDelimiter,
                PECrossSection = newCableType.PECrossSection,
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
                    Pairs = c.Pairs,
                    Conductors = c.Conductors,
                    Delimiter = c.Delimiter,
                    CrossSection = c.CrossSection,
                    GroundingDelimiter = c.GroundingDelimiter,
                    PEConductors = c.PEConductors,
                    PEDelimiter = c.PEDelimiter,
                    PECrossSection = c.PECrossSection,
                    Diameter = c.Diameter,
                    Shield = c.Shield,
                    BendingRadius = c.BendingRadius,
                    WeightPerKm = c.WeightPerKm,
                    Manufacturer = c.Manufacturer,
                    PartNumber = c.PartNumber
                })
                .OrderBy(c => c.Type)
                .ThenBy(c => c.Conductors)
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
                Pairs = cableType.Pairs,
                Conductors = cableType.Conductors,
                Delimiter = cableType.Delimiter,
                CrossSection = cableType.CrossSection,
                GroundingDelimiter = cableType.GroundingDelimiter,
                PEConductors = cableType.PEConductors,
                PEDelimiter = cableType.PEDelimiter,
                PECrossSection = cableType.PECrossSection,
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
            cableTypeToUpdate.Pairs = cableType.Pairs;
            cableTypeToUpdate.Conductors = cableType.Conductors;
            cableTypeToUpdate.Delimiter = cableType.Delimiter;
            cableTypeToUpdate.CrossSection = cableType.CrossSection;
            cableTypeToUpdate.GroundingDelimiter = cableType.GroundingDelimiter;
            cableTypeToUpdate.PEConductors = cableType.PEConductors;
            cableTypeToUpdate.PEDelimiter = cableType.PEDelimiter;
            cableTypeToUpdate.PECrossSection = cableType.PECrossSection;
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
                Pairs = cableTypeToUpdate.Pairs,
                Conductors = cableTypeToUpdate.Conductors,
                Delimiter = cableTypeToUpdate.Delimiter,
                CrossSection = cableTypeToUpdate.CrossSection,
                GroundingDelimiter = cableTypeToUpdate.GroundingDelimiter,
                PEConductors = cableTypeToUpdate.PEConductors,
                PEDelimiter = cableTypeToUpdate.PEDelimiter,
                PECrossSection = cableTypeToUpdate.PECrossSection,
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
