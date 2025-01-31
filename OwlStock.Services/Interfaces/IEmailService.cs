using OwlStock.Infrastructure.Common.EmailTemplates;
using OwlStock.Infrastructure.Common.EmailTemplates.Inquiry;

namespace OwlStock.Services.Interfaces
{
    public interface IEmailService
    {
        Task Send(EmailTemplateBaseDTO dto);
        Task SendInquiry(SendInquiryEmailTemplateDTO dto);
    }
}
