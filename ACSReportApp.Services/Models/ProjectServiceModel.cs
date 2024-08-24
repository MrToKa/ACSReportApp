using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSReportApp.Services.Models
{
    public class ProjectServiceModel
    {
        public ProjectServiceModel()
        {
            //UsersProjects = new List<UserProjectServiceModel>();
        }

        public Guid Id { get; set; }

        public string Number { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Contractor { get; set; } 

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //public virtual List<UserProjectServiceModel> UsersProjects { get; set; }
    }
}
