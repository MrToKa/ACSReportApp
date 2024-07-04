using ACSReportApp.Services.Contracts;
using ACSReportApp.Services.Models;
using ACSReportApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using ACSReportApp.Models;

namespace ACSReportApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IACSReportAppDbRepository repo;

        public ProjectService(IACSReportAppDbRepository repo)
        {
            this.repo = repo;
        }

        public Task<ProjectServiceModel> CreateProjectAsync(ProjectServiceModel project)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectServiceModel> DeleteProjectAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectServiceModel> GetProjectAsync(Guid projectId)
        {
            var project = await this.repo.All<Project>()
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new ArgumentException("Project not found.");
            }

            return new ProjectServiceModel()
            {
                Id = project.Id,
                Number = project.Number,
                Name = project.Name,
                Description = project.Description,
                DateCreated = project.DateCreated                
            };
        }

        public Task<List<ProjectServiceModel>> GetProjectsAsync()
        {
            var projects = this.repo.All<Project>()
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Name = p.Name,
                    Description = p.Description,
                    DateCreated = p.DateCreated
                });

            return projects.ToListAsync();            
        }

        public Task<ProjectServiceModel> UpdateProjectAsync(ProjectServiceModel project, Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
