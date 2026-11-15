using OwlStock.Domain.Enumerations;

namespace OwlStock.Infrastructure.Common.EmailTemplates.GiftCard
{
    public class GiftCardEmailTemplates
    {
        public static string CreateGiftCardTemplate(Guid id, string giftCardNumber, PhotoShootType photoshootType, string price)
        {
            return 
            @$"<!DOCTYPE html>
            <html lang=""en"">
            <head>
              <meta charset=""UTF-8"">
              <title>Booking Confirmation</title>
            </head>
            <body style=""margin:0; padding:0; background-color:#f4f6f8; font-family: Arial, Helvetica, sans-serif;"">

              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#f4f6f8; padding:24px 0;"">
                <tr>
                  <td align=""center"">
        
                    <!-- Container -->
                    <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#ffffff; border-radius:10px; overflow:hidden; box-shadow:0 6px 18px rgba(0,0,0,0.08);"">

                      <!-- Header -->
                      <tr>
                        <td style=""background-color:#f9fafb; padding:24px; text-align:center;"">
                          <div style=""margin:0;"">
                            <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png""/>
                          </div>
                      </td>
                      </tr>

                      <!-- Body -->
                      <tr>
                        <td style=""padding:32px; color:#111827;"">

                          <h2 style=""margin-top:0; font-size:22px;"">
                            Успешно създаден подаручен ваучер 📸
                          </h2>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            Здравейте,
                          </p>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            Благодарим Ви за поръчката! Остава само една последна стъпка, преди този ваучер   да се превърне в незабравим подарък:
                          </p>

                            <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                За да извършите плащането, преведете цената на ваучера по банков път, като използвате следните данни:
                            </p>
              
                             <!-- Order Details -->
                            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""margin:24px 0; border-collapse:collapse;"">
                                <tr>
                                    <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                    <strong>IBAN</strong>
                                    </td>
                                    <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                    BG80BNBG96611020345678
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                    <strong>BIC</strong>
                                    </td>
                                    <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                    UBBSBGSF
                                    </td>
                                </tr>
                                <tr>
                            </table>

                        <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                        <i>Въведете номера на ваучера като забележка при превода: <b>{giftCardNumber}</b></i>
                        </p>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            <b>Очакваме Вашето плащане по банков път, за да активираме ваучера.</b>
                          </p>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            След като получим и потвърдим плащането, ваучерът ще бъде активиран и ще бъде готов за използване.
                          </p>
              
                          <!-- Order Details -->
                          <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""margin:24px 0; border-collapse:collapse;"">
                            <tr>
                              <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                <strong>Номер:</strong>
                              </td>
                              <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                {giftCardNumber}
                              </td>
                            </tr>
                            <tr>
                              <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                <strong>Фотосесия</strong>
                              </td>
                              <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                {photoshootType}
                              </td>
                            </tr>
                            <tr>
                              <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                <strong>Цена</strong>
                              </td>
                              <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                €{price}
                              </td>
                            </tr>
                            <tr>
                          </table>

                          <!-- CTA -->
                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            При всякакви възникнали въпроси или идеи, които искате да обсъдим,
                            отговорете на този имейл — ще се радваме да помогнем.
                          </p>

                          <div style=""text-align:center; margin:32px 0;"">
                            <a href=""https://photonic.bg/podarachni-vaucheri/vaucher?id={id}""
                                style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                              ПРЕГЛЕД НА ПОРЪЧКАТА
                            </a>
                          </div>


                          <p style=""font-size:15px; margin-top:24px;"">
                            Поздрави,<br>
                            <strong>Екипът на PHOTONIC</strong><br>
                          </p>

                        </td>
                      </tr>

                      <!-- Footer -->
                      <tr>
                        <td style=""background-color:#f9fafb; padding:20px; text-align:center; font-size:13px; color:#6b7280;"">
                          © {DateTime.Now.Year} Photonic. Всички права запазени!<br>
                          <a href=""http://photonic.bg"" style=""color:#111827; text-decoration:none;"">photonic.bg</a>
                        </td>
                      </tr>

                    </table>

                  </td>
                </tr>
              </table>

            </body>
            </html>";
        }
    }
}
