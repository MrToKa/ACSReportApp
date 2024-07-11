using ACSReportApp.Data;
using ACSReportApp.Models;
using ACSReportApp.Models.Enums;

var context = new ACSReportAppDbContext();
context.Database.EnsureDeleted();
Console.WriteLine("Database deleted!");
context.Database.EnsureCreated();
Console.WriteLine("Database created!");

context.Projects.Add(new Project
{
    Number = "P000001",
    Name = "Test Project",
    Description = "Test Description",
    Contractor = "Test Contractor",
    DateCreated = DateTime.UtcNow,
});

context.Projects.Add(new Project
{
    Number = "P000002",
    Name = "Test Project 2",
    Description = "Test Description 2",
    Contractor = "Test Contractor 2",
    DateCreated = DateTime.UtcNow,
});

context.Projects.Add(new Project
{
    Number = "P000003",
    Name = "Test Project 3",
    Description = "Test Description 3",
    Contractor = "Test Contractor 3",
    DateCreated = DateTime.UtcNow,
});

context.SaveChanges();

Console.WriteLine("Projects added to the database!");

//var projects = context.Projects.ToList();
//foreach (var project in projects)
//{
//    Console.WriteLine($"Project Number: {project.Number}");
//    Console.WriteLine($"Project Name: {project.Name}");
//    Console.WriteLine($"Project Description: {project.Description}");
//    Console.WriteLine($"Project Contractor: {project.Contractor}");
//    Console.WriteLine($"Project Date Created: {project.DateCreated}");
//    Console.WriteLine();
//}

context.CableTypes.Add(new CableType
{
    Type = "GAALFLEX VFD CABLES",
    Description = "Suitable for Mining applications!",
    Purpose = "Power cable",
    Voltage = 400,
    Pairs = null,
    Conductors = 4,
    Delimiter = CableDelimiter.Numbers,
    CrossSection = 1.5,
    GroundingDelimiter = null,
    PEConductors = null,
    PEDelimiter = null,
    PECrossSection = null,
    Diameter = 11.3,
    Shield = true,
    BendingRadius = 25,
    WeightPerKm = 95,
    Manufacturer = "ELETTROTEK KABEL",
    PartNumber = "33055G72041M15",
});

context.CableTypes.Add(new CableType
{
    Type = "GAALFLEX VFD CABLES",
    Description = "Suitable for Mining applications!",
    Purpose = "Power cable",
    Voltage = 400,
    Pairs = null,
    Conductors = 3,
    Delimiter = CableDelimiter.Colors,
    CrossSection = 2.5,
    GroundingDelimiter = CableDelimiter.Grounding,
    PEConductors = 3,
    PEDelimiter = CableDelimiter.Numbers,
    PECrossSection = 0.5,
    Diameter = 11.8,
    Shield = true,
    BendingRadius = 35,
    WeightPerKm = 148,
    Manufacturer = "ELETTROTEK KABEL",
    PartNumber = "33055G72037M25",
});

context.SaveChanges();

Console.WriteLine("Cable Types added to the database!");

//var cableTypes = context.CableTypes.ToList();
//foreach (var cableType in cableTypes)
//{
//    Console.WriteLine($"Cable Type: {cableType.Type}");
//    Console.WriteLine($"Cable Description: {cableType.Description}");
//    Console.WriteLine($"Cable Purpose: {cableType.Purpose}");
//    Console.WriteLine($"Cable Voltage: {cableType.Voltage}");
//    Console.WriteLine($"Cable Conductors: {cableType.Conductors}");
//    Console.WriteLine($"Cable Delimiter: {cableType.Delimiter}");
//    Console.WriteLine($"Cable Cross Section: {cableType.CrossSection}");
//    Console.WriteLine($"Cable Grounding Delimiter: {cableType.GroundingDelimiter}");
//    Console.WriteLine($"Cable PE Conductors: {cableType.PEConductors}");
//    Console.WriteLine($"Cable PE Delimiter: {cableType.PEDelimiter}");
//    Console.WriteLine($"Cable PE Cross Section: {cableType.PECrossSection}");
//    Console.WriteLine($"Cable Diameter: {cableType.Diameter}");
//    Console.WriteLine($"Cable Shield: {cableType.Shield}");
//    Console.WriteLine($"Cable Bending Radius: {cableType.BendingRadius}");
//    Console.WriteLine($"Cable Weight Per Km: {cableType.WeightPerKm}");
//    Console.WriteLine($"Cable Manufacturer: {cableType.Manufacturer}");
//    Console.WriteLine($"Cable Part Number: {cableType.PartNumber}");
//    Console.WriteLine();
//}