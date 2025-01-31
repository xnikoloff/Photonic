namespace OwlStock.Infrastructure.Common.EmailTemplates.Inquiry
{
    public class InquiryEmailTemplates
    {
        public static string SendInquiryTemplate(string content, string name)
        {
            return $"<!DOCTYPE html><html><body><div style=\"width:100%\"><h1 style=\"text-align:center\">Ново запитване</h1></div><div style=\"width:100%;;margin-top:50px;\"><h4 style=\"text-align:center;\">{content}</h4></div><div style=\"width:100%;margin-top:50px;\"><h4>{name}</h4></div></body></html>";
        }
    }
}
