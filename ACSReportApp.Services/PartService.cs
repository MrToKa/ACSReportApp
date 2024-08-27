using ACSReportApp.Data.Repositories;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using ACSReportApp.Models;
using ACSReportApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ACSReportApp.Services
{
    public class PartService : IPartService
    {
        private readonly IACSReportAppDbRepository repo;

        public PartService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public Task AddPartsFromFileAsync(Stream stream)
        {
            throw new NotImplementedException();
        }

        public async Task<PartServiceModel> CreatePartAsync(PartServiceModel part)
        {
            var newPart = new Part()
            {
                PartType = part.PartType,
                OrderNumber = part.OrderNumber,
                Manufacturer = part.Manufacturer,
                Width = part.Width,
                Height = part.Height,
                Length = part.Length,
                Weight = part.Weight,
                Diameter = part.Diameter,
                Description = part.Description,
                Picture = part.Picture,
                Remarks = part.Remarks,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = null,
                ApplicationUserId = null,
                Measurement = part.Measurement == null ? Measurement.None : Enum.Parse<Measurement>(part.Measurement)      
            };

            if (string.IsNullOrWhiteSpace(part.Measurement))
            {
                part.Measurement = Measurement.None.ToString();
            }
            else
            {
                newPart.Measurement = Enum.Parse<Measurement>(part.Measurement);
            }

            await this.repo.AddAsync(newPart);
            await this.repo.SaveChangesAsync();

            return new PartServiceModel()
            {
                Id = newPart.Id,
                PartType = newPart.PartType,
                OrderNumber = newPart.OrderNumber,
                Manufacturer = newPart.Manufacturer,
                Width = newPart.Width,
                Height = newPart.Height,
                Length = newPart.Length,
                Weight = newPart.Weight,
                Diameter = newPart.Diameter,
                Description = newPart.Description,
                Measurement = newPart.Measurement.ToString(),
                Picture = newPart.Picture,
                Remarks = newPart.Remarks
            };
        }

        public async Task DeletePartAsync(int id)
        {
            var partToDelete = await this.repo.All<Part>()
                .FirstOrDefaultAsync(p => p.Id == id) 
                ?? throw new ArgumentException("Part not found.");
            partToDelete.IsDeleted = true;
            partToDelete.LastModifiedOn = DateTime.UtcNow;

            await this.repo.SaveChangesAsync();
        }

        public async Task<PartServiceModel> GetPartAsync(int id)
        {
            var partToReturn = await this.repo.All<Part>()
                .FirstOrDefaultAsync(p => p.Id == id) 
                ?? throw new ArgumentException("Part not found.");

            return new PartServiceModel()
            {
                Id = partToReturn.Id,
                PartType = partToReturn.PartType,
                OrderNumber = partToReturn.OrderNumber,
                Manufacturer = partToReturn.Manufacturer,
                Width = partToReturn.Width,
                Height = partToReturn.Height,
                Length = partToReturn.Length,
                Weight = partToReturn.Weight,
                Diameter = partToReturn.Diameter,
                Description = partToReturn.Description,
                Measurement = partToReturn.Measurement.ToString(),
                Picture = partToReturn.Picture,
                Remarks = partToReturn.Remarks
            };
        }

        public async Task<List<PartServiceModel>> GetPartsAsync(string partType)
        {
            return await this.repo.All<Part>()
                .Where(p => p.PartType == partType)
                .Where(p => p.IsDeleted == false)
                .Select(p => new PartServiceModel()
                {
                    Id = p.Id,
                    PartType = p.PartType,
                    OrderNumber = p.OrderNumber,
                    Manufacturer = p.Manufacturer,
                    Width = p.Width,
                    Height = p.Height,
                    Length = p.Length,
                    Weight = p.Weight,
                    Diameter = p.Diameter,
                    Description = p.Description,
                    Measurement = p.Measurement.ToString(),
                    Picture = p.Picture,
                    Remarks = p.Remarks
                })
                .ToListAsync();
        }

        public async Task<List<string>> GetPartsNumbersForSearchAsync()
        {
            return await this.repo.All<Part>()
                .Select(p => p.OrderNumber)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetPartsTypesAsync()
        {
            return await this.repo.All<Part>()
                .Select(p => p.PartType)
                .Distinct()
                .ToListAsync();
        }

        public async Task<PartServiceModel> UpdatePartAsync(PartServiceModel part)
        {
            var updatedPart = await this.repo.All<Part>()
                .Where(p => p.Id == part.Id)
                .FirstOrDefaultAsync() ?? throw new ArgumentException("Part not found.");

            updatedPart.PartType = part.PartType;
            updatedPart.OrderNumber = part.OrderNumber;
            updatedPart.Manufacturer = part.Manufacturer;
            updatedPart.Width = part.Width;
            updatedPart.Height = part.Height;
            updatedPart.Length = part.Length;
            updatedPart.Weight = part.Weight;
            updatedPart.Diameter = part.Diameter;
            updatedPart.Description = part.Description;
            updatedPart.Picture = part.Picture;
            updatedPart.Remarks = part.Remarks;
            updatedPart.LastModifiedOn = DateTime.UtcNow;

            if (string.IsNullOrWhiteSpace(part.Measurement))
            {
                part.Measurement = Measurement.None.ToString();
            }
            else
            {
                updatedPart.Measurement = Enum.Parse<Measurement>(part.Measurement);
            }

            await this.repo.SaveChangesAsync();

            return await this.GetPartAsync(part.Id);
        }
    }
}
