using OwlStock.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Infrastructure.Common.EmailTemplates.GiftCard
{
    public class GiftCardEmailTemplateDTO : EmailTemplateBaseDTO
    {
        public Guid Id { get; set; }
        
        [Required]
        public PhotoShootType PhotoShootType { get; set; }

        public string? GiftCardNumber { get; set; }

        public string? Price { get; set; }
    }
}
