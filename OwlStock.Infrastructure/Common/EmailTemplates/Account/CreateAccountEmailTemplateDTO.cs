namespace OwlStock.Infrastructure.Common.EmailTemplates.Account
{
    public class CreateAccountEmailTemplateDTO : EmailTemplateBaseDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
