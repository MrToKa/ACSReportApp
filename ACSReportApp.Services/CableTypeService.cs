using ACSReportApp.Data.Repositories;
using ACSReportApp.Models;
using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components.Forms;
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
            bool cableTypeExists = await this.repo.All<CableType>()
                .AnyAsync(c => c.Type == cableType.Type && c.CrossSection == cableType.CrossSection && c.Manufacturer == cableType.Manufacturer);

            if (cableTypeExists)
            {
                return await RestoreCableTypeAsync(cableType);
            }

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

        public async Task<CableTypeServiceModel> RestoreCableTypeAsync(CableTypeServiceModel cableType)
        {
            CableType? cableTypeToRestore = await this.repo.All<CableType>()
                .FirstOrDefaultAsync(c => c.Type == cableType.Type && c.CrossSection == cableType.CrossSection && c.Manufacturer == cableType.Manufacturer);

            cableTypeToRestore!.IsDeleted = false;

            await this.repo.SaveChangesAsync();

            return new CableTypeServiceModel()
            {
                Id = cableTypeToRestore.Id,
                Type = cableTypeToRestore.Type,
                Description = cableTypeToRestore.Description,
                Purpose = cableTypeToRestore.Purpose,
                Voltage = cableTypeToRestore.Voltage,
                CrossSection = cableTypeToRestore.CrossSection,
                Diameter = cableTypeToRestore.Diameter,
                Shield = cableTypeToRestore.Shield,
                BendingRadius = cableTypeToRestore.BendingRadius,
                WeightPerKm = cableTypeToRestore.WeightPerKm,
                Manufacturer = cableTypeToRestore.Manufacturer,
                PartNumber = cableTypeToRestore.PartNumber
            };
        }

        public async Task DeleteCableTypeAsync(int cableTypeId)
        {
            var cableTypeToDelete = await this.repo.All<CableType>()
                .FirstOrDefaultAsync(c => c.Id == cableTypeId);

            if (cableTypeToDelete != null)
            {
                cableTypeToDelete.IsDeleted = true;
                await this.repo.SaveChangesAsync();
            }
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

        public async Task UploadFromFileAsync(IBrowserFile file)
        {
            List<CableTypeServiceModel> cables = new List<CableTypeServiceModel>();
            string? value = null;

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
                    CableTypeServiceModel cable = new CableTypeServiceModel();
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
                            cable.Type = value;
                        }
                        else if (cell.CellReference == "B" + rowNumber)
                        {
                            cable.Description = value;
                        }
                        else if (cell.CellReference == "C" + rowNumber)
                        {
                            cable.Purpose = value;
                        }
                        else if (cell.CellReference == "D" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                cable.Voltage = null;
                            }
                            else
                            {
                                cable.Voltage = int.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "E" + rowNumber)
                        {
                            cable.CrossSection = value;
                        }
                        else if (cell.CellReference == "F" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                cable.Diameter = null;
                            }
                            else
                            {
                                cable.Diameter = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "G" + rowNumber)
                        {
                            cable.Shield = bool.Parse(value);
                        }
                        else if (cell.CellReference == "H" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                cable.BendingRadius = null;
                            }
                            else
                            {
                                cable.BendingRadius = double.Parse(value);
                            }
                        }
                        else if (cell.CellReference == "I" + rowNumber)
                        {
                            cable.WeightPerKm = double.Parse(value);
                        }
                        else if (cell.CellReference == "J" + rowNumber)
                        {
                            cable.Manufacturer = value;
                        }
                        else if (cell.CellReference == "K" + rowNumber)
                        {
                            if (value == null || value == string.Empty)
                            {
                                cable.PartNumber = null;
                            }
                            else
                            {
                                cable.PartNumber = value;
                            }
                        }
                    }

                    cables.Add(cable);
                }

                foreach (var cable in cables)
                {
                    await this.CreateCableTypeAsync(cable);
                }
            }
        }
    }
}
