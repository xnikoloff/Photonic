using OwlStock.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Domain.Entities
{
    public class Valentine
    {
        [Key]
        public int Id { get; set; }
        public ValentineEnum Request { get; set; }
        public string? RequestDescription { get; set; }
    }
}
