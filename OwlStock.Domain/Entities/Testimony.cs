using Microsoft.AspNetCore.Identity;
using OwlStock.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class Testimony
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Име е задължително поле")]
        [MinLength(ModelConstraints.TestimonyNameMinLength, ErrorMessage = ModelConstraints.TestimonyFirstNameMinLengthErrorMessage)]
        [MaxLength(ModelConstraints.TestimonyNameMaxLength, ErrorMessage = ModelConstraints.TestimonyFirstNameMaxLengthErrorMessage)]
        [Display(Name = "Име")]
        public string? PersonFirstName { get; set; }

        [MinLength(ModelConstraints.TestimonyNameMinLength, ErrorMessage = ModelConstraints.TestimonyLastNameNameMinLengthErrorMessage)]
        [MaxLength(ModelConstraints.TestimonyNameMaxLength, ErrorMessage = ModelConstraints.TestimonyLastNameNameMaxLengthErrorMessage)]
        [Display(Name = "Фамилия")]
        public string? PersonLastName { get; set; }

        public string? PersonJob { get; set; }

        [Required(ErrorMessage = "Оценката със звезди е задължителна")]
        [Range(ModelConstraints.TestimonyStarsMinCount, ModelConstraints.TestimonyStarsMaxCount, ErrorMessage = ModelConstraints.TestimonyDescriptionStarsErrorMessage)]
        [Display(Name = "Оценка")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Описание е задължително поле")]
        [MinLength(ModelConstraints.TestimonyContentMinLength, ErrorMessage = ModelConstraints.TestimonyDescriptionMinLengthErrorMessage)]
        [MaxLength(ModelConstraints.TestimonyContentMaxLength, ErrorMessage = ModelConstraints.TestimonyDescriptionMaxLengthErrorMessage)]
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
