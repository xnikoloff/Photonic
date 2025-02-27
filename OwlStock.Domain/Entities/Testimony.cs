using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Testimony
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Име е задължително поле")]
        [Display(Name = "Име")]
        public string? PersonFirstName { get; set; }

        [Required(ErrorMessage = "Фамилия е задължително поле")]
        [Display(Name = "Фамилия")]
        public string? PersonLastName { get; set; }

        [Required(ErrorMessage = "Оценката със звезди е задължителна")]
        [Display(Name = "Оценка")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Описание е задължително поле")]
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
