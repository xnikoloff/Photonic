using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Announcement
    {
        [Key]
        public Guid Id { get; set; }

        public string? Content { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public DateTime? HiddenOn { get; set; }

        public DateTime? UnhiddenOn { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public string? CreatedById { get; set; }

        [ForeignKey(nameof(EditedBy))]
        public string? EditedById { get; set; }

        [ForeignKey(nameof(HiddenBy))]
        public string? HiddenById { get; set; }

        [ForeignKey(nameof(UnhiddenBy))]
        public string? UnhiddenById { get; set; }

        public IdentityUser? CreatedBy { get; set; }

        public IdentityUser? EditedBy { get; set; }

        public IdentityUser? HiddenBy { get; set; }

        public IdentityUser? UnhiddenBy { get; set; }
    }
}
