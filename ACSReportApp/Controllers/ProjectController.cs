using ACSReportApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ACSReportApp.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectAsync(Guid projectId)
        {
            try
            {
                var project = await this.projectService.GetProjectAsync(projectId);
                return this.Ok(project);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var model = await this.projectService.GetProjectsAsync();
            return View(model);
        }
    }
}
