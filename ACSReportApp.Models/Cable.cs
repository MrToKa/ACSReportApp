using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACSReportApp.Models
{
    public class Cable
    {
        [Key]
        public int Id { get; set; }

        public string? Revision { get; set; }

        public bool IsLastRevision { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        /// <summary>
        /// Gets or sets the TAG of the cable. Usually is the Name of the cable.
        /// </summary>
        [Required]
        public string Tag { get; set; } = null!;

        /// <summary>
        /// Gets or sets the cable type. It is a foreign key to CableType table 
        /// </summary>

        [ForeignKey(nameof(CableType))]
        public int? CableTypeId { get; set; }


        public CableType? CableType { get; set; }

        /// <summary>
        /// Gets or sets the system of the cable. It is a part of P&ID.
        /// </summary>        
        public string? System { get; set; }

        /// <summary>
        /// Gets or sets the starting location of the cable. Usually this is the KKS of the consumer.
        /// </summary>
        
        public string? FromLocation { get; set; }

        /// <summary>
        /// Gets or sets description of the starting location. Usually this is the description of the consumer.
        /// </summary>
        [Required]
        public string FromDevice { get; set; } = null!;

        /// <summary>
        /// Gets or sets the target location of the cable. Usually this is the KKS of the enclosure/device.
        /// </summary>
        
        public string? ToLocation { get; set; }

        /// <summary>
        /// Gets or sets description of the target location. It consist of a descriptive text of the consumer and its purpose. It can include a system name too.
        /// </summary>
        [Required]
        public string ToDevice { get; set; } = null!;

        /// <summary>
        /// Gets or sets the routing path for the cable. It consists of cable trays and conduits. The routing should be done in from -> to location order.
        /// </summary>
        public string? Routing { get; set; }

        /// <summary>
        /// Gets or sets the design length according the project documentation.
        /// </summary>

        public int? DesignLength { get; set; }

        /// <summary>
        /// Gets or sets the install length according the site situation.
        /// </summary>
        public int? InstallLength { get; set; }

        /// <summary>
        /// Gets or sets the date when the cable has been pulled.
        /// </summary>
        public DateTime? PullDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the cable has been connected on from location.
        /// </summary>
        public DateTime? ConnectedFrom { get; set; }

        /// <summary>
        /// Gets or sets the date when the cable has been connected to the consumer.
        /// </summary>
        public DateTime? ConnectedTo { get; set; }

        /// <summary>
        /// Gets or sets the date when the cable is tested for continuity.
        /// </summary>
        public DateTime? TestedDate { get; set; }
        
        public string? Delivery { get; set; }

        /// <summary>
        /// Gets or sets the remarks for changes on anything unusual about the cable.
        /// </summary>

        public string? Remarks { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
