using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Testimony
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Име")]
        public string? PersonFirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string? PersonLastName { get; set; }

        [Display(Name = "Оценка")]
        public int Stars { get; set; }

        [Display(Name = "Описание")]
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
