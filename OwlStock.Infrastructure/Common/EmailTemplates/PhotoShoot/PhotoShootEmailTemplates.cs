using OwlStock.Domain.Enumerations;
using static System.Net.WebRequestMethods;

namespace OwlStock.Infrastructure.Common.EmailTemplates.PhotoShoot
{
    public static class PhotoShootEmailTemplates
    {
        public static string CreatePhotoShootTemplate(DateTime date, PhotoShootType photoshootType, decimal price, Guid photoshootId)
        {
            string dateString = date == default ? "-" : date.ToString();
            decimal priceEuro = Math.Round(price / 1.95583M, 2);
            string euroString = "";

            //make sure the decimal separator is a dot
            if (priceEuro.ToString().Contains(','))
            {
                euroString = priceEuro.ToString().Replace(',', '.');
            }

            return @$"<!DOCTYPE html>
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
                                <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png"" style=""width: 20%;""/>
                              </div>
	                      <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#B78D65"">PHOTONIC</h1>

                            </td>
                          </tr>

                          <!-- Body -->
                          <tr>
                            <td style=""padding:32px; color:#111827;"">

                              <h2 style=""margin-top:0; font-size:22px;"">
                                Успешно резервирана фотосесия 📸
                              </h2>

                              <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                Здравейте,
                              </p>

                              <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                Благодарим ви за резервацията! В таблицата ще намерите детайли за вашата фотосесия:
                              </p>

                              <!-- Booking Details -->
                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""margin:24px 0; border-collapse:collapse;"">
                                <tr>
                                  <td style=""padding:12px; background-color:#f9fafb; border:1px solid #e5e7eb;"">
                                    <strong>Дата</strong>
                                  </td>
                                  <td style=""padding:12px; border:1px solid #e5e7eb;"">
                                    {dateString}
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
                                    {euroString} € / {price}.00 лв.
                                  </td>
                                </tr>
                              </table>

                              <!-- CTA -->
                              <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                При всякакви възникнали въпроси или идеи, които искате да обсъдим,
                                отговорете на този имейл — ще се радваме да помогнем.
                              </p>

                              <div style=""text-align:center; margin:32px 0;"">
                                <a href=""http://www.photonic.bg/Photoshoot/PhotoshootById/{photoshootId}""
                                   style=""display:inline-block; padding:14px 28px; background-color:#B78D65; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                  ПРЕГЛЕД НА РЕЗЕРВАЦИЯТА
                                </a>
                              </div>


                              <p style=""font-size:15px; margin-top:24px;"">
                                Поздрави,<br>
                                <strong>Екипът на Фотоник</strong><br>
                              </p>

                            </td>
                          </tr>

                          <!-- Footer -->
                          <tr>
                            <td style=""background-color:#f9fafb; padding:20px; text-align:center; font-size:13px; color:#6b7280;"">
                              © {DateTime.Now.Year} Photonic. Всички права запазени!<br>
                              <a href=""http://www.photonic.bg"" style=""color:#111827; text-decoration:none;"">photonic.bg</a>
                            </td>
                          </tr>

                        </table>

                      </td>
                    </tr>
                  </table>

                </body>
                </html>";
        }

        public static string CreatePhotoShootTemplateDreampix(DateTime date, PhotoShootType photoshootType)
        {
            return $"<div class=\"container\"> <div class=\"content\"> <h2 class=\"username\">Здравей,</h2> <br> <h1 class=\"text\">Направена е нова рервация.</i></h1> <hr> <div class=\"details\"> <table> <tbody> <tr> <td>Date:</td> <td><i>{date.ToShortDateString()}</i></td> </tr> <tr> <td>Type:</td> <td><i>{photoshootType}</i></td> </tr> </tbody> </table> </div> <hr> <div class=\"greetings\"</div> <hr> <div class=\"footer\"> <h1>OwlStock</h1> <br> <h4>2023</h4> </div> </div> </div> <style> *{{margin: 0;padding: 5px 8px;}}hr{{margin: 10px 10px;padding: 0;}}.container{{font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;width: 100%;text-align: center;}}.container .content{{width: 100%;margin: 0 auto;padding: 20px 0;background-color: #EBEAE1;}}.container .content .details table{{margin: 0 auto;}}.container .content .greetings h2{{margin-top: 20px;}}</style> ";
        }

        public static string UpdatePhotoShootTemplate(Guid photoshootId)
        {
            return $"<!doctypehtml><html lang=en><meta charset=UTF-8><meta content=\"width=device-width,initial-scale=1\"name=viewport><title>Страхотни новини!</title><body style=font-family:Verdana,Geneva,Tahoma,sans-serif><div id=container style=width:100%><div style=\"width:100%;margin:0 auto\"class=container-main><div id=container-main-header><div id=container-main-header-logo style=width:100%;text-align:center><img src=https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic_UPPER_dark.png style=width:50%></div></div><div id=container-main-title style=\"width:100%;margin:60px 0\"><h2 style=text-align:center;color:#000>Снимките от Вашата фотосесия са <span style=color:#eaa636>готови</span>!</h2></div><div id=container-main-text style=margin-top:50px><p>Всички снимки от Вашата фотосесия са налични в профила Ви. Може да ги прегледате или изтеглите от Вашата лична галерия.<p style=margin-top:40px><a href=http://www.flash-studio.co/Photoshoot/PhotoshootById/{photoshootId} style=\"background:#eaa636;padding:10px 30px;text-decoration:none;color:#000\"><b>Моята галерия</b></a><p style=margin-top:40px;color:#000>Благодарим Ви, че изплозвате нашите услуги!<p style=color:#000;margin-top:40px>Поздрави,<p style=color:#000>Екипът на PHOTONIC</div><div id=container-main-footer style=margin-top:50px><div id=container-main-footer-text style=\"margin:0 auto;background-color:#eaa636;padding:5px 0\"><h4 style=text-align:center;color:#000><a href=http://www.flash-studio.co style=text-decoration:none;color:#000>PHOTONIC</a> © {DateTime.Now.Year}</h4></div></div></div></div>";
        }

        public static string UpdatePhotoShootDataTemplate(Guid photoshootId, PhotoShootType photoshootType, string photoshootNumber, DateTime date)
        {
            return $"<!doctypehtml><html lang=en><meta charset=UTF-8><meta content=\"width=device-width,initial-scale=1\"name=viewport><title>Актуализирана фотосесия</title><body style=font-family:Verdana,Geneva,Tahoma,sans-serif><div id=container style=width:100%><div style=\"width:100%;margin:0 auto\"class=container-main><div id=container-main-header><div id=container-main-header-logo style=width:100%;text-align:center><img src=https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic_UPPER_dark.png style=width:50%></div></div><div id=container-main-title style=\"width:100%;margin:40px 0\"><h2 style=text-align:center;color:#000>Данните за фотосесия №{photoshootNumber} бяха актуализирани <span style=color:#eaa636>успешно</span>!</h2></div><hr><div id=container-main-table-details style=width:100%;font-size:1.2rem><table style=\"width:100%;margin:20px 0\"><tr><td><b>Фотосесия</b><td>{photoshootType}<tr><td style=text-align:left><b>Дата</b><td style=text-align:left>{date}</table></div><hr><div id=container-main-text style=margin-top:40px><p style=color:#000>Повече информация може да откриете <a href=http://www.flash-studio.co/Photoshoot/PhotoshootById/{photoshootId} style=text-decoration:none;color:#eaa636><b>тук</b></a>.<p style=margin-top:40px;color:#000>Благодарим Ви, че изплозвате нашите услуги!<p style=color:#000;margin-top:40px>Поздрави,<p style=color:#000>Екипът на PHOTONIC</div><div id=container-main-footer style=margin-top:50px><div id=container-main-footer-text style=\"margin:0 auto;background-color:#eaa636;padding:5px 0\"><h4 style=text-align:center;color:#000><a href=http://www.flash-studio.co style=text-decoration:none;color:#000>PHOTONIC</a> © {DateTime.Now.Year}</h4></div></div></div></div>";
        }

        public static string DeclinePhotoShootTemplate(Guid photoshootId)
        {
            return $"<!doctypehtml><html lang=\"en\"><meta charset=\"UTF-8\"><meta content=\"width=device-width,initial-scale=1\"name=\"viewport\"><title>Отказана фотосесия</title><body style=\"font-family:Verdana,Geneva,Tahoma,sans-serif\"><div id=\"container\"style=\"width:100%\"><div style=\"width:100%;margin:0 auto\"class=\"container-main\"><div id=\"container-main-header\"><div id=\"container-main-header-logo\"style=\"width:100%;text-align:center\"><img src=\"https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic_UPPER_dark.png\"style=\"width:50%\"></div></div><div id=\"container-main-title\"style=\"width:100%;margin-top:100px\"><h2 style=\"text-align:center;color:#000\">Отказана фотосесия</h2></div><div id=\"container-main-text\"style=\"margin-top:60px\"><p style=\"color:#000\">Здравейте,<p style=\"color:#000\">Благодарим Ви за направената резервация! За съжаление, поради независещи от нас обстоятелства, на избраната от Вас дата няма да бъде възможно да проведем фотосесията.<p style=\"color:#000;margin-top:40px\">Може да направите нова резервация, като изберете друга дата и час през нашата онлайн форма за резервация.<p style=\"margin-top:40px\"><a href=\"http://www.flash-studio.co/PhotoShoot/Reserve\"style=\"text-decoration:none;padding:10px 15px;color:#000;background:#eaa636\"><b>НОВА РЕЗЕРВАЦИЯ</b></a><p style=\"color:#000;margin-top:40px\">Искрено се извиняваме за причиненото неудобство!<p style=\"margin-top:40px\"><a href=\"http://flash-studio.co/Photoshoot/PhotoshootById/{photoshootId}\"style=\"text-decoration:none;padding:10px 15px;color:#000;background:#eaa636\"><b>ПРЕГЛЕД НА ЗАЯВКАТА</b></a><p style=\"color:#000;margin-top:40px\">Благодарим Ви, че изплозвате нашите услуги!<p style=\"color:#000;margin-top:40px\">С уважение,<p style=\"color:#000\">Екипът на PHOTONIC</div><div id=\"container-main-footer\"style=\"margin-top:50px\"><div id=\"container-main-footer-text\"style=\"margin:0 auto;background-color:#eaa636;padding:5px 0\"><h4 style=\"text-align:center;color:#000\"><a href=\"http://www.flash-studio.co\"style=\"text-decoration:none;color:#000\">PHOTONIC</a> © {DateTime.Now.Year}</h4></div></div></div></div>";
        }

        public static string CancelPhotoShootTemplate(Guid photoshootId)
        {
            return $"<!doctypehtml><html lang=\"en\"><meta charset=\"UTF-8\"><meta content=\"width=device-width,initial-scale=1\"name=\"viewport\"><title>Отменена фотосесия</title><body style=\"font-family:Verdana,Geneva,Tahoma,sans-serif\"><div id=\"container\"style=\"width:100%\"><div style=\"width:100%;margin:0 auto\"class=\"container-main\"><div id=\"container-main-header\"><div id=\"container-main-header-logo\"style=\"width:100%;text-align:center\"><img src=\"https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic_UPPER_dark.png\"style=\"width:50%\"></div></div><div id=\"container-main-title\"style=\"width:100%;margin-top:100px\"><h2 style=\"text-align:center;color:#000\">Отменена фотосесия</h2></div><div id=\"container-main-text\"style=\"margin-top:60px\"><p style=\"color:#000\">Здравейте,<p style=\"color:#000\">Вашата резервация за фотосесия беше отменена.<p style=\"color:#000;margin-top:40px\">Ще се радваме да раборим заедно отново в бъдеще! Може да направите нова резервация от тук:<p style=\"margin-top:40px\"><a href=\"http://www.flash-studio.co/PhotoShoot/Reserve\"style=\"text-decoration:none;padding:10px 15px;color:#000;background:#eaa636\"><b>НОВА РЕЗЕРВАЦИЯ</b></a><p style=\"color:#000;margin-top:40px\">Благодарим Ви, че изплозвате нашите услуги!<p style=\"color:#000;margin-top:40px\">С уважение,<p style=\"color:#000\">Екипът на PHOTONIC</div><div id=\"container-main-footer\"style=\"margin-top:50px\"><div id=\"container-main-footer-text\"style=\"margin:0 auto;background-color:#eaa636;padding:5px 0\"><h4 style=\"text-align:center;color:#000\"><a href=\"http://www.flash-studio.co\"style=\"text-decoration:none;color:#000\">PHOTONIC</a> © {DateTime.Now.Year}</h4></div></div></div></div>";
        }
    }
}
