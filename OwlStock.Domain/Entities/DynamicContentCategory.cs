using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class DynamicContentCategory
    {
        public DynamicContentCategory()
        {
            DynamicContents = new HashSet<DynamicContent>(); 
        }

        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public ICollection<DynamicContent>? DynamicContents { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public string? CreatedById { get; set; }

        public IdentityUser? CreatedBy { get; set; }
    }
}
