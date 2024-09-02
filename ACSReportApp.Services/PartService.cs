using ACSReportApp.Data.Repositories;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using ACSReportApp.Models;
using ACSReportApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ACSReportApp.Services
{
    public class PartService : IPartService
    {
        private readonly IACSReportAppDbRepository repo;

        public PartService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public async Task<PartServiceModel> CreatePartAsync(PartServiceModel part)
        {
            bool partExists = await this.repo.All<Part>()
                .AnyAsync(p => p.OrderNumber == part.OrderNumber && p.IsDeleted == true);

            if (partExists)
            {
                return await RestorePartAsync(part);
            }

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

        public async Task<PartServiceModel> RestorePartAsync(PartServiceModel part)
        {
            Part? restorePart = await repo.All<Part>()
                .FirstOrDefaultAsync(p => p.OrderNumber == part.OrderNumber);

            restorePart!.IsDeleted = false;

            await this.repo.SaveChangesAsync();

            return new PartServiceModel()
            {
                Id = restorePart.Id,
                PartType = restorePart.PartType,
                OrderNumber = restorePart.OrderNumber,
                Manufacturer = restorePart.Manufacturer,
                Width = restorePart.Width,
                Height = restorePart.Height,
                Length = restorePart.Length,
                Weight = restorePart.Weight,
                Diameter = restorePart.Diameter,
                Description = restorePart.Description,
                Measurement = restorePart.Measurement.ToString(),
                Picture = restorePart.Picture,
                Remarks = restorePart.Remarks
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

        public async Task<PartServiceModel> GetPartAsync(string partNumber)
        {
            var partToReturn = await this.repo.All<Part>()
                .FirstOrDefaultAsync(p => p.OrderNumber.Contains(partNumber))
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
                .Where(p => p.IsDeleted == false)
                .Select(p => p.OrderNumber)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetPartsTypesAsync()
        {
            return await this.repo.All<Part>()
                .Where(p => p.IsDeleted == false)
                .Select(p => p.PartType)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetMeasurementAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Measurement)).ToList());
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

        public async Task AssignImageAsync(int partId, string imageTag)
        {
            var part = await this.repo.All<Part>()
                .FirstOrDefaultAsync(p => p.Id == partId)
                ?? throw new ArgumentException("Part not found.");

            part.Picture = imageTag;
            await this.repo.SaveChangesAsync();
        }

        public async Task UploadFromFileAsync(IBrowserFile file)
        {
            List<PartServiceModel> parts = new List<PartServiceModel>();
            string? value = null;

            //using Stream stream = new FileStream(file.Name, FileMode.Open);
            using MemoryStream memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            MemoryStream stream = memoryStream;

            using SpreadsheetDocument document = SpreadsheetDocument.Open(stream, false);

            if (document is not null)
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                for (int i = 1; i < sheetData.Elements<Row>().Count(); i++)
                {
                    PartServiceModel part = new PartServiceModel();
                    Row row = sheetData.Elements<Row>().ElementAt(i);
                    // get the row number from outerxml
                    int rowNumber = int.Parse(row.RowIndex);


                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        value = cell.InnerText;

                        if (cell.DataType != null && cell.DataType == CellValues.SharedString)
                        {
                            SharedStringTablePart stringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                            if (stringTablePart != null)
                                value = stringTablePart.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                        }

                        if (cell.CellReference == "A" + rowNumber)
                        {
                            part.PartType = value;
                        }
                        else if (cell.CellReference == "B" + rowNumber)
                        {
                            part.OrderNumber = value;
                        }
                        else if (cell.CellReference == "C" + rowNumber)
                        {
                            part.Manufacturer = value;
                        }
                        else if (cell.CellReference == "D" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                part.Width = null;
                            }
                            else
                            {
                                part.Width = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "E" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                part.Height = null;
                            }
                            else
                            {
                                part.Height = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "F" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                part.Length = null;
                            }
                            else
                            {
                                part.Length = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "G" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                part.Weight = null;
                            }
                            else
                            {
                                part.Weight = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "H" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                part.Diameter = null;
                            }
                            else
                            {
                                part.Diameter = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "I" + rowNumber)
                        {
                            part.Description = value;
                        }
                        else if (cell.CellReference == "J" + rowNumber)
                        {
                            part.Measurement = value;
                        }
                        else if (cell.CellReference == "K" + rowNumber)
                        {
                            part.Picture = value;
                        }
                        else if (cell.CellReference == "L" + rowNumber)
                        {
                            part.Remarks = value;
                        }
                    }

                    parts.Add(part);
                }

                foreach (var part in parts)
                {
                    await this.CreatePartAsync(part);
                }
            }

        }

        public async Task<List<PartServiceModel>> GetAllPartsAsync()
        {
            return await this.repo.All<Part>()
                .Where(p => p.IsDeleted == false)
                .Select(p => new PartServiceModel()
                {
                    Id = p.Id,
                    PartType = p.PartType,
                    Manufacturer = p.Manufacturer,
                    OrderNumber = p.OrderNumber,
                    Description = p.Description                    
                }).ToListAsync();
        }
    }
}
