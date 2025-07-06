using Microsoft.Extensions.Configuration;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.Interfaces;
using System.Net;
using System.Net.Mail;
using OwlStock.Infrastructure.Common.EmailTemplates.PhotoShoot;
using OwlStock.Infrastructure.Common.EmailTemplates;
using OwlStock.Infrastructure.Common.EmailTemplates.Account;
using OwlStock.Infrastructure.Common.EmailTemplates.Inquiry;
using Microsoft.Extensions.Logging;
using OwlStock.Services.DTOs.PhotoShoot;

namespace OwlStock.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpKey;
        
        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _smtpHost = _configuration.GetValue<string>("Smpt:Host") ?? throw new NullReferenceException("Host is null");
            _smtpPort = _configuration.GetValue<int>("Smpt:Port");
            _smtpUser = _configuration.GetValue<string>("Smpt:Login") ?? throw new NullReferenceException("Smtp:Login is null");
            _smtpKey = _configuration.GetValue<string>("Smpt:Key") ?? throw new NullReferenceException("Smtp:Key is null");
            _logger = logger;
        }

        public async Task SendInquiry(SendInquiryEmailTemplateDTO dto)
        {
            await Send(dto);
        }

        public async Task<bool> Send(EmailTemplateBaseDTO dto)
        {
            SmtpClient client = new(_smtpHost)
            {
                Port = _smtpPort,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_smtpUser, _smtpKey),
                EnableSsl = true,
            };

            MailMessage[] messages;

            try
            {
                if (dto.EmailTemplate is EmailTemplate.CreatePhotoShoot)
                {
                    //if email template is for created photoshoot
                    //send template to user and to Photonic
                    messages = new MailMessage[]
                    {
                    new
                    (
                        "hristiyan.at.nikoloff@gmail.com",
                        dto?.Recipient ?? throw new NullReferenceException($"{nameof(dto.Recipient)} is null"),
                        dto.Topic,
                        GetTemplate(dto)
                    ),

                    //second email is always sent to Photonic
                    new
                    (
                        "hristiyan.at.nikoloff@gmail.com",
                        "hristiyan.at.nikoloff@gmail.com",
                        dto.Topic,
                        GetTemplatePhoton(dto)
                    ),

                    };
                }

                else
                {
                    //if email template is not for created photoshoot
                    //send template to user only
                    messages = new MailMessage[]
                    {
                    new
                    (
                        dto.From,
                        dto.Recipient ?? throw new NullReferenceException($"{nameof(dto.Recipient)} is null"),
                        dto.Topic,
                        GetTemplate(dto)
                    )

                    };
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }

            for (int i = 0; i < messages.Length; i++) 
            {
                try
                {
                    await client.SendMailAsync(messages[i]);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                    return false;
                }
            }

            return true;

        }

        public string GetTemplate(EmailTemplateBaseDTO dto)
        {
            switch (dto.EmailTemplate)
            {
                case EmailTemplate.CreatePhotoShoot:
                {
                    return PhotoShootEmailTemplates.CreatePhotoShootTemplate
                    (
                        ((PhotoShootEmailTemplateDTO)dto).Date ?? new DateTime(),
                        ((PhotoShootEmailTemplateDTO)dto).Type,
                        ((PhotoShootEmailTemplateDTO)dto).PhotoShootId
                    );
                }

                case EmailTemplate.UpdatePhotosForPhotoShoot:
                {
                    return PhotoShootEmailTemplates.UpdatePhotoShootTemplate
                        (
                            ((UpdatePhotoShootEmailTemplateDTO)dto).PhotoShootId
                        );
                }

                case EmailTemplate.DeclinePhotoShoot:
                {
                    return PhotoShootEmailTemplates.DeclinePhotoShootTemplate
                        (
                            ((UpdatePhotoShootEmailTemplateDTO)dto).PhotoShootId
                        );
                }

                case EmailTemplate.CancelPhotoShoot:
                {
                    return PhotoShootEmailTemplates.CancelPhotoShootTemplate
                    (
                        ((UpdatePhotoShootEmailTemplateDTO)dto).PhotoShootId
                    );
                }

                case EmailTemplate.CreateAccount:
                {
                    return AccountEmailTemplates.CreateAccountTemplate
                    (
                        ((CreateAccountEmailTemplateDTO)dto)?.Password ?? ""
                    );
                }

                case EmailTemplate.CreateConfirmedAccount:
                {
                    return AccountEmailTemplates.CreateConfirmedAccountTemplate();
                }

                case EmailTemplate.ConfirmAccount:
                {
                    return AccountEmailTemplates.ConfirmAccountTemplate
                    (
                        ((ConfirmAccountEmailTemplate)dto)?.ConfirmationLink ?? ""
                    );
                }

                case EmailTemplate.ResetPassword:
                {
                    return AccountEmailTemplates.ResetPasswordTemplate
                    (
                        ((ResetPasswordEmailTemplateDTO)dto)?.CallBackURL ?? ""
                    );
                }

                case EmailTemplate.SendInquiry:
                {
                    return InquiryEmailTemplates.SendInquiryTemplate
                    (
                        ((SendInquiryEmailTemplateDTO)dto)?.Name ?? "",
                        ((SendInquiryEmailTemplateDTO)dto)?.Content ?? ""
                    );
                }

                default:
                {
                    throw new ArgumentException($"{dto.EmailTemplate} is invalid {nameof(EmailTemplate)}");
                }
            }
        }

        public string GetTemplatePhoton(EmailTemplateBaseDTO dto)
        {
            switch (dto.EmailTemplate)
            {
                case EmailTemplate.CreatePhotoShoot:
                {
                        return PhotoShootEmailTemplates.CreatePhotoShootTemplateDreampix
                    (
                         ((PhotoShootEmailTemplateDTO)dto).Date ?? new DateTime(),
                         ((PhotoShootEmailTemplateDTO)dto).Type
                    );
                }

                default:
                {
                    throw new ArgumentException($"{dto.EmailTemplate} is invalid {nameof(EmailTemplate)}");
                }
            }
        }
    }
}
