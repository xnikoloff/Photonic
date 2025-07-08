namespace OwlStock.Infrastructure.Common.EmailTemplates.Inquiry
{
    public class InquiryEmailTemplates
    {
        public static string SendInquiryTemplate(string content, string name)
        {
            return $"<!doctypehtml><html lang=en><meta charset=UTF-8><meta content=\"width=device-width,initial-scale=1\"name=viewport><title>Запитване от {name}</title><body style=font-family:Verdana,Geneva,Tahoma,sans-serif><div style=width:100% id=container><div style=\"width:50%;margin:0 auto\"class=container-main><div style=margin-top:50px id=container-main-text><p style=font-size:1.2rem>{content}</div></div></div>";
        }
    }
}
