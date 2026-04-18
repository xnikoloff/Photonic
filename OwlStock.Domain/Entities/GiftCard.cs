using Microsoft.AspNetCore.Identity;
using OwlStock.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwlStock.Domain.Entities
{
    public class GiftCard
    {
        [Key]
        public int Id { get; set; }

        public string? Receiver { get; set; }

        public PhotoShootType PhotoShootType { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string? IdentityUserId { get; set; }

        public IdentityUser? IdentityUser { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
