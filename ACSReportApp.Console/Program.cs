using ACSReportApp.Data;
using ACSReportApp.Models;

var context = new ACSReportAppDbContext();
context.Database.EnsureCreated();

context.Projects.Add(new Project
{
    Number = "P000001",
    Name = "Test Project",
    Description = "Test Description",
    Contractor = "Test Contractor",
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