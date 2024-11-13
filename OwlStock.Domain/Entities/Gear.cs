using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Gear
    {
        [Key]
        public Guid Id { get; set; }
        
        public string? CameraBrand { get; set; }

        public string? CameraModel { get; set; }

        public string? CameraLens { get; set; }

        public string?  AdditionalInformation { get; set; }

        public DateTime? CreatedOn { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public string? CreatedById { get; set; }

        public IdentityUser? CreatedBy { get; set; }
    }
}
