namespace OwlStock.Infrastructure.Common.EmailTemplates.Inquiry
{
    public class SendInquiryEmailTemplateDTO : EmailTemplateBaseDTO
    {
        public string? Name { get; set; }
        public string? Content { get; set; }    
    }
}
