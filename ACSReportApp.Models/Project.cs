using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class Project
    {
        public Project()
        {
            UsersProjects = new List<UserProject>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets project number. The pattern for name is "P######", where # is a single digit.
        /// </summary>
        [Required]
        //[MaxLength(ProjectConstants.NumberMaxLength)]
        //[RegularExpression(ProjectConstants.NameRegex)]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets project name.
        /// </summary>
        [Required]
        //[MaxLength(ProjectConstants.NameMaxName)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a short description of the project. It can include base requirements about the design, manufacturing, erection or commissioning of the project.
        /// </summary>
        //[MaxLength(ProjectConstants.DescriptionMaxLength)]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets contractor name.
        /// </summary>
        [Required]
        //[MaxLength(ProjectConstants.ContractorMaxLength)]
        public string Contractor { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedOn { get; set; }

        public virtual List<UserProject> UsersProjects { get; set; }
    }
}