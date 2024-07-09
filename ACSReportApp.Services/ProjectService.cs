﻿using ACSReportApp.Services.Contracts;
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

        public async Task<ProjectServiceModel> DeleteProjectAsync(Guid projectId)
        {
            var project = await this.repo.All<Project>()
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                throw new ArgumentException("Project not found.");
            }

            project.IsDeleted = true;
            project.DeletedOn = DateTime.UtcNow;
            
            await this.repo.SaveChangesAsync();

            return new ProjectServiceModel()
            {
                Id = project.Id,
                Number = project.Number,
                Name = project.Name,
                Description = project.Description,
                DateCreated = project.DateCreated
            };
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
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Name = p.Name,
                    Description = p.Description,
                    DateCreated = p.DateCreated
                })
                .OrderBy(p => p.Number);

            return projects.ToListAsync();
        }

        public async Task<ProjectServiceModel> UpdateProjectAsync(ProjectServiceModel project, Guid projectId)
        {
            var projectToUpdate = await this.repo.All<Project>()
                .FirstOrDefaultAsync(p => p.Id == projectId);

            projectToUpdate.Number = project.Number;
            projectToUpdate.Name = project.Name;
            projectToUpdate.Description = project.Description;

            await this.repo.SaveChangesAsync();

            return new ProjectServiceModel()
            {
                Id = projectToUpdate.Id,
                Number = projectToUpdate.Number,
                Name = projectToUpdate.Name,
                Description = projectToUpdate.Description,
                DateCreated = projectToUpdate.DateCreated
            };
        }
    }
}
