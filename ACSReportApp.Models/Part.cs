﻿using ACSReportApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACSReportApp.Models
{
    public class Part
    {
        public Part()
        {
            PartAssemblies = new List<PartAssemblyPart>();
            CableTrays = new List<CableTray>();
        }

        [Key]
        public int Id { get; set; }
        public string PartType { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? Weight { get; set; }
        public double? Diameter { get; set; }
        public string Description { get; set; } = null!;
        public Measurement? Measurement { get; set; }
        public string? Picture { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedOn { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ModifiedBy { get; set; }
        public string? ApplicationUserId { get; set; }
        public virtual List<PartAssemblyPart> PartAssemblies { get; set; }
        public virtual List<CableTray> CableTrays { get; set; }
    }
}
