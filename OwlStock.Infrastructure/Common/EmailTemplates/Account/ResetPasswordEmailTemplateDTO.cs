namespace OwlStock.Infrastructure.Common.EmailTemplates.Account
{
    public class ResetPasswordEmailTemplateDTO : EmailTemplateBaseDTO
    {
        public string? CallBackURL { get; set; }
    }
}
