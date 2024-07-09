using ACSReportApp.Data;
using ACSReportApp.Models;

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

var projects = context.Projects.ToList();
foreach (var project in projects)
{
    Console.WriteLine($"Project Number: {project.Number}");
    Console.WriteLine($"Project Name: {project.Name}");
    Console.WriteLine($"Project Description: {project.Description}");
    Console.WriteLine($"Project Contractor: {project.Contractor}");
    Console.WriteLine($"Project Date Created: {project.DateCreated}");
    Console.WriteLine();
}