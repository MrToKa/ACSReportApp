using ACSReportApp.Models;

namespace ACSReportApp.Services.Models
{
    public class CableServiceModel
    {
        public int Id { get; set; }

        public string? Revision { get; set; }

        public bool IsLastRevision { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public string Tag { get; set; } = null!;

        public int? CableTypeId { get; set; }

        public CableTypeServiceModel? CableType { get; set; }

        public string? System { get; set; }

        public string? FromLocation { get; set; }

        public string FromDevice { get; set; } = null!;

        public string? ToLocation { get; set; }

        public string ToDevice { get; set; } = null!;

        public string? Routing { get; set; }

        public int? DesignLength { get; set; }

        public int? InstallLength { get; set; }

        public DateTime? PullDate { get; set; }

        public DateTime? ConnectedFrom { get; set; }

        public DateTime? ConnectedTo { get; set; }

        public DateTime? TestedDate { get; set; }

        public string? Delivery { get; set; }

        public string? Remarks { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
