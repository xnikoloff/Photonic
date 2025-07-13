using OwlStock.Domain.Enumerations;

namespace OwlStock.Infrastructure.Common.EmailTemplates.PhotoShoot
{
    public class UpdatePhotoshootDataEmailTemplateDTO : EmailTemplateBaseDTO
    {
        public PhotoShootType PhotoShootType { get; set; }
        public string? PhotoshootNumber { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
