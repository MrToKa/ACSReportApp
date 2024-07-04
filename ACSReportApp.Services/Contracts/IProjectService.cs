using ACSReportApp.Services.Models;

namespace ACSReportApp.Services.Contracts
{
    public interface IProjectService
    {
        Task<ProjectServiceModel> GetProjectAsync(Guid projectId);

        Task<List<ProjectServiceModel>> GetProjectsAsync();

        Task<ProjectServiceModel> CreateProjectAsync(ProjectServiceModel project);

        Task<ProjectServiceModel> UpdateProjectAsync(ProjectServiceModel project, Guid projectId);

        Task<ProjectServiceModel> DeleteProjectAsync(Guid projectId);
    }
}
