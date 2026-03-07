using OwlStock.Domain.Enumerations;

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

            else
            {
                euroString = priceEuro.ToString();
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
	                      <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#"">PHOTONIC</h1>

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
                                   style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
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
                                    <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png"" style=""width: 20%;"" />
                                  </div>
                                  <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#627582"">PHOTONIC</h1>
                                </td>
                              </tr>

                              <!-- Body -->
                              <tr>
                                <td style=""padding:32px; color:#111827;"">

                                  <h2 style=""margin-top:0; font-size:22px;"">
                                    Снимките от Вашата фотосесия са <span style=""color:#627582"">готови</span>!
                                  </h2>

	                          <p>Всички снимки от Вашата фотосесия са налични в профила Ви. Може да ги прегледате  или изтеглите от Вашата лична галерия.</p>

                                  <!-- CTA -->
                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    При всякакви възникнали въпроси или идеи, които искате да обсъдим,
                                    отговорете на този имейл — ще се радваме да помогнем.
                                  </p>

                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""http://www.photonic.bg/Photoshoot/PhotoshootById/{photoshootId}""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                      ПРЕГЛЕД НА ГАЛЕРИЯТА
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

        public static string UpdatePhotoShootDataTemplate(Guid photoshootId, PhotoShootType photoshootType, string photoshootNumber, DateTime date, decimal price)
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
                                    <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png"" style=""width: 20%;"" />
                                  </div>
                                  <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#627582"">PHOTONIC</h1>
                                </td>
                              </tr>

                              <!-- Body -->
                              <tr>
                                <td style=""padding:32px; color:#111827;"">

                                  <h2 style=""margin-top:0; font-size:22px;"">
                                    Данните за фотосесия №{photoshootNumber} бяха актуализирани успешно! 
                                  </h2>
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
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
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

        public static string DeclinePhotoShootTemplate(Guid photoshootId)
        {
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
                                    <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png"" style=""width: 20%;"" />
                                  </div>
                                  <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#627582"">PHOTONIC</h1>
                                </td>
                              </tr>

                              <!-- Body -->
                              <tr>
                                <td style=""padding:32px; color:#111827;"">

                                  <h2 style=""margin-top:0; font-size:22px;"">
                                    Отказана фотосесия 
                                  </h2>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Здравейте,
                                  </p>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Благодарим Ви за направената резервация! За съжаление, поради независещи от нас обстоятелства, на избраната от Вас дата няма да бъде възможно да проведем фотосесията
                                  </p>
	                          <p>Може да направите нова резервация, като изберете друга дата и час през нашата онлайн форма за резервация.</p>

                                  <!-- CTA -->
                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    При всякакви възникнали въпроси или идеи, които искате да обсъдим,
                                    отговорете на този имейл — ще се радваме да помогнем.
                                  </p>

                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""http://www.photonic.bg/Photoshoot/PhotoshootById/{photoshootId}""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
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

        public static string CancelPhotoShootTemplate(Guid photoshootId)
        {
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
                                    <img src=""https://raw.githubusercontent.com/xnikoloff/OwlStock/refs/heads/develop/OwlStock.Web/wwwroot/photonic-logo.png"" style=""width: 20%;"" />
                                  </div>
                                  <h1 style=""margin-top:5px;font-family:fantasy;letter-spacing:5px;color:#627582"">PHOTONIC</h1>
                                </td>
                              </tr>

                              <!-- Body -->
                              <tr>
                                <td style=""padding:32px; color:#111827;"">

                                  <h2 style=""margin-top:0; font-size:22px;"">
                                    Отменена фотосесия
                                  </h2>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Здравейте,
                                  </p>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Вашата резервация за фотосесия беше отменена. Ще се радваме да раборим заедно отново в бъдеще!
                                  </p>

                                  <!-- CTA -->
                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    При всякакви възникнали въпроси или идеи, които искате да обсъдим,
                                    отговорете на този имейл — ще се радваме да помогнем.
                                  </p>

	                         <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Нова резервация може да направите от тук:
                                  </p>

                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""http://www.photonic.bg/Photoshoot/Reserve/""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                      НОВА РЕЗЕРВАЦИЯТА
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
    }
}
