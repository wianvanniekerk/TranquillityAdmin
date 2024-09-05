using MimeKit;
using MailKit.Net.Smtp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp1.Data.Appointments
{
    internal class NewClientDetails
    {
        private static string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";
        public static bool isEmailSent = false;

        public static string GetClientEmail(int clientId)
        {
            string query = "SELECT Email FROM Client WHERE ClientID = @ClientID";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
            if (dt.Rows.Count > 0)
            {
                string email = dt.Rows[0]["Email"].ToString();
                return $"{email}";
            }

            return string.Empty;
        }

        private static string GenerateToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32];
                rng.GetBytes(tokenData);
                string base64Token = Convert.ToBase64String(tokenData);
                string urlSafeToken = base64Token.Replace('+', '-').Replace('/', '_').Replace("=", "");
                return urlSafeToken;
            }
        }

        public static void OnAppointmentInserted(object sender, AppointmentInsertedEventArgs e)
        {
            isEmailSent = false;

            if (isEmailSent)
                return;

            DataRow row = e.Row;
            int appointmentID = e.AppointmentID;
            if (row["IsNewClient"] == DBNull.Value || Convert.ToInt32(row["IsNewClient"]) == 0)
            {
                return;
            }

            string clientId = row["ClientID"].ToString();
            string email = GetClientEmail(Convert.ToInt32(clientId));

            string token = GenerateToken();
            DateTime expireDate = DateTime.Now.AddHours(24);

            try
            {
                using (var connection = new MySqlConnection(connect))
                {
                    connection.Open();
                    string insertTokenQuery = "INSERT INTO AppointmentTokens (AppointmentID, ClientID, Token, ExpireDate) VALUES (@AppointmentID, @ClientID, @Token, @ExpireDate)";
                    using (var command = new MySqlCommand(insertTokenQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.Parameters.AddWithValue("@Token", token);
                        command.Parameters.AddWithValue("@ExpireDate", expireDate);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Rows affected: " + rowsAffected);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting token: " + ex.Message);
            }


            SendEmail(email, token);

            isEmailSent = true;
        }


        private static void SendEmail(string email, string token)
        {
            string resetLink = $"https://tranquillity-salon-website-production.up.railway.app/forms/client?token={token}";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tranquillity Salon", "info@tranquillitysalon.co.za"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Complete Your Profile - Tranquillity Salon";
            message.Body = new TextPart("html")
            {
                Text = $@"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Complete Your Profile - Tranquillity Salon</title>
            </head>
            <body style=""margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #f0f4f8;"">
                <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""background-color: #f0f4f8;"">
                    <tr>
                        <td style=""padding: 20px 0;"">
                            <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""600"" style=""margin: 0 auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);"">
                                <!-- Header -->
                                <tr>
                                    <td style=""background-color: #0d9488; padding: 30px 40px; text-align: center;"">
                                        <img src=""https://res.cloudinary.com/daiaxqvvr/image/upload/v1721458782/tranquility-logo_exggpt.png"" alt=""Tranquillity Salon"" style=""max-width: 200px; height: auto;"">
                                    </td>
                                </tr>
                                <!-- Content -->
                                <tr>
                                    <td style=""padding: 40px;"">
                                        <h1 style=""color: #1f2937; font-size: 24px; margin-bottom: 20px;"">Please complete your profile</h1>
                                        <p style=""color: #4b5563; font-size: 16px; line-height: 1.5; margin-bottom: 20px;"">Please click the button below to complete your profile before your appointment:</p>
                                        <table role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""margin: 0 auto;"">
                                            <tr>
                                                <td style=""border-radius: 4px; background-color: #0d9488;"">
                                                    <a href=""{resetLink}"" target=""_blank"" style=""border: none; border-radius: 4px; color: #ffffff; display: inline-block; font-size: 16px; font-weight: bold; padding: 12px 24px; text-decoration: none;"">Complete Profile</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Footer -->
                                <tr>
                                    <td style=""background-color: #f3f4f6; padding: 20px 40px; text-align: center;"">
                                        <p style=""color: #6b7280; font-size: 14px; margin: 0;"">© 2024 Tranquillity Salon. All rights reserved.</p>
                                        <p style=""color: #6b7280; font-size: 14px; margin: 10px 0 0;"">661 Levinia Street, Garsfontein, 0081</p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </body>
            </html>"
            };

            using (var client = new SmtpClient())
            {
                client.Connect(EnvConfig.emailHost, Convert.ToInt32(EnvConfig.emailPort), true);
                client.Authenticate(EnvConfig.emailDomain, EnvConfig.emailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
