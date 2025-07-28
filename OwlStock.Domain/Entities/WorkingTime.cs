using System.ComponentModel.DataAnnotations;

namespace OwlStock.Domain.Entities
{
    public class WorkingTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Начало")]
        public int Start { get; set; }

        [Required]
        [Display(Name = "Край")]
        public int End { get; set; }
    }
}
