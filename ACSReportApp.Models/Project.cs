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

        [Required]
        //[MaxLength(ProjectConstants.NumberMaxLength)]
        //[RegularExpression(ProjectConstants.NameRegex)]
        public string Number { get; set; }

        [Required] 
        public string Name { get; set; }

        //[MaxLength(ProjectConstants.DescriptionMaxLength)]
        public string? Description { get; set; }

        //[Required]
        //[MaxLength(ProjectConstants.ContractorMaxLength)]
        public string Contractor { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedOn { get; set; }

        public virtual List<UserProject> UsersProjects { get; set; }
    }
}