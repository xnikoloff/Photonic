using OwlStock.Domain.Enumerations;

namespace OwlStock.Infrastructure.Common.EmailTemplates
{
    public class EmailTemplateBaseDTO
    {
        public string From { get; set; } = "hristiyan.at.nikoloff@gmail.com";
        public string? Recipient { get; set; } = "hristiyan.at.nikoloff@gmail.com";
        public string? Topic { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
        public Guid PhotoShootId { get; set; }
    }
}
