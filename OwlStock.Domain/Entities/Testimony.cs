using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Testimony
    {
        [Key]
        public Guid Id { get; set; }

        public string? PersonFirstName { get; set; }

        public string? PersonLastName { get; set; }

        public int Stars { get; set; }

        public string? Content { get; set; }

        public bool IsApproved { get; set; }
        
        public bool IsHidden { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime? ApprovedOn { get; set; }
        
        public DateTime? HiddenOn { get; set; }
        
        public DateTime? UnhiddenOn { get; set; }
        
        [ForeignKey(nameof(IdentityUser))]
        public string? IdentityUserId { get; set; }

        public IdentityUser? IdentityUser { get; set; }
    }
}
