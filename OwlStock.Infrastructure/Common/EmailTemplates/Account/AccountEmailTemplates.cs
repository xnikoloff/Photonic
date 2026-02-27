namespace OwlStock.Infrastructure.Common.EmailTemplates.Account
{
    public static class AccountEmailTemplates
    {
        public static string CreateAccountTemplate(string password)
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
                                    Създадохме Вашия профил
                                  </h2>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Здравейте,
                                  </p>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Създадохме личен профил за Вас и сега можете да се възползвате от всички функционалости, налични на нашия сайт.
                                  </p>

                                  <!-- CTA -->
                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    <span style=""color:#627582""><b>Вашата парола</b></span>: {password}
                                  </p>

	                         <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Вашият профил може да достъпите от тук:
                                  </p>

                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""https://photonic.bg/PhotoShoot/MyPhotoShoots""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                      ПРОФИЛ
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
                                  <a href=""https://photonic.bg/"" style=""color:#111827; text-decoration:none;"">photonic.bg</a>
                                </td>
                              </tr>

                            </table>

                          </td>
                        </tr>
                      </table>

                    </body>
                    </html>";
        }

        public static string CreateConfirmedAccountTemplate()
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
                                    Профилът Ви беше потвърден успешно!
                                  </h2>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Здравейте,
                                  </p>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Вие успешно потвърдихте профила си и сега може да се възползвате от всички функционалости, налични на нашия сайт.
                                  </p>


                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""https://photonic.bg//PhotoShoot/MyPhotoShoots""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                      ВАШИЯТ ПРОФИЛ
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

        public static string ConfirmAccountTemplate(string confirmationLink)
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
                                    Благодарим Ви за регистрацията!
                                  </h2>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Здравейте,
                                  </p>

                                  <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    Благодарим Ви, че се регистрирахте! Остава единствено да активирате Вашия профил и ще може да се възползвате от всички функционалности, налични на <a href=""http://www.flash-studio.co"" style=""text-decoration: none; color:#627582""><b>PHOTONIC</b></a>
                                  </p>



	                         <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                                    За да активирате профила си, кликнете върху бутона отдолу:
                                  </p>

                                  <div style=""text-align:center; margin:32px 0;"">
                                    <a href=""{confirmationLink}""
                                       style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                                      АКТИВИРАЙ
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

        public static string ResetPasswordTemplate(string callbackURL)
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
                            Възстановяване на парола
                          </h2>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            Здравейте,
                          </p>

                          <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            Получихме заявка от Вас за възстановяване на парола*. За да възстановите паролата, кликнете върху бутона отдолу:
                          </p>


                          <div style=""text-align:center; margin:32px 0;"">
                            <a href=""{callbackURL}""
                               style=""display:inline-block; padding:14px 28px; background-color:#627582; color:#ffffff; text-decoration:none; border-radius:6px; font-size:15px;"">
                              ВЪЗСТАНОВИ ПАРОЛА
                            </a>
                          </div>

            <p style=""font-size:15px; line-height:1.6; margin:16px 0;"">
                            <i>*Ако не Вие сте изпратили тази заявка, може да игнорирате този имей. Акаунтът ви е защитен.
                          </p></i>

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
