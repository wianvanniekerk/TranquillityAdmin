using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Data.Communication;
using Org.BouncyCastle.Tls;
using WindowsFormsApp1.Views;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.Communication.Email
{
    public partial class CommunicationEmail : Form
    {
        private DataHandlerEmail handler = new DataHandlerEmail();
        DataTable staffDataTable = new DataTable();
        DataTable clientDataTable = new DataTable();

        public CommunicationEmail()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private string GenerateSignature(string senderName, string senderRole, string senderPhoneNumber, string senderEmail)
        {
            return $@"
    <table cellpadding='0' cellspacing='0' border='0' style='font-family: Arial, sans-serif; font-size: 14px; line-height: 1.6; color: #4a5568;'>
        <tr>
            <td style='padding-bottom: 10px;'>
                <strong style='color: #38b2ac;'>{HtmlEncode(senderName)}</strong>
            </td>
        </tr>
        <tr>
            <td style='color: #4a5568;'>{HtmlEncode(senderRole)}</td>
        </tr>
        <tr>
            <td style='color: #4a5568;'>Tranquillity Beauty Salon</td>
        </tr>
        <tr>
            <td style='color: #4a5568;'>Phone: {HtmlEncode(senderPhoneNumber)}</td>
        </tr>
        <tr>
            <td>
                <a href='mailto:{HtmlEncode(senderEmail)}' style='color: #38b2ac; text-decoration: none;'>{HtmlEncode(senderEmail)}</a>
            </td>
        </tr>
    </table>";
        }

        private void btnEmailSend_Click(object sender, EventArgs e)
        {
            try
            {
                string senderEmail = cmbEmailSender.Text.ToString();
                string senderName = handler.GetStaffName(senderEmail);
                string senderPhoneNumber = handler.GetStaffPhoneNumber(senderEmail);
                string senderRole = handler.GetStaffRole(senderEmail);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Tranquillity Beauty Salon", senderEmail));
                message.Subject = txtEmailSubject.Text;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $@"
    <html>
        <head>
            <style>
                @import url('https://fonts.googleapis.com/css2?family=Dancing+Script:wght@400..700&display=swap');
                body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #4a5568; background-color: #f7fafc; }}
                .container {{ max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); }}
                .header {{ background: linear-gradient(to right, #38b2ac, #ecc94b); padding: 20px; text-align: center; }}
                .header h1 {{ font-family: 'Dancing Script', cursive; color: white; font-size: 36px; margin: 0; }}
                .content {{ padding: 30px; }}
                .signature {{ margin-top: 30px; border-top: 2px solid #e2e8f0; padding-top: 20px; }}
                .footer {{ background-color: #f7fafc; padding: 15px; text-align: center; font-size: 12px; color: #718096; }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
<img src='https://res.cloudinary.com/daiaxqvvr/image/upload/v1721458782/tranquility-logo_exggpt.png' alt='Tranquillity Beauty Salon' />
                </div>
                <div class='content'>
                    <div>{HtmlEncode(rtbEmailBody.Text)}</div>
                    <div class='signature'>
                        {GenerateSignature(senderName, senderRole, senderPhoneNumber, senderEmail)}
                    </div>
                </div>
                <div class='footer'>
                    <p>&copy; {DateTime.Now.Year} Tranquillity Beauty Salon. All rights reserved.</p>
                </div>
            </div>
        </body>
    </html>"
                };

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(EnvConfig.emailHost, Convert.ToInt32(EnvConfig.emailPort), true);
                    client.Authenticate(EnvConfig.emailDomain, EnvConfig.emailPassword);

                    foreach (DataRowView recipient in lstEmailRecipients.SelectedItems)
                    {
                        message.To.Clear();
                        string recipientEmail = recipient["Email"].ToString();
                        message.To.Add(new MailboxAddress("", recipientEmail));
                        client.Send(message);
                    }

                    client.Disconnect(true);
                }

                MessageBox.Show("Emails sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }

        private string HtmlEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var encoded = new StringBuilder(text.Length);

            foreach (char c in text)
            {
                switch (c)
                {
                    case '<':
                        encoded.Append("&lt;");
                        break;
                    case '>':
                        encoded.Append("&gt;");
                        break;
                    case '&':
                        encoded.Append("&amp;");
                        break;
                    case '"':
                        encoded.Append("&quot;");
                        break;
                    case '\'':
                        encoded.Append("&#39;");
                        break;
                    case '\n':
                        encoded.Append("<br>");
                        break;
                    case '\r':
                        break;
                    default:
                        if (c > 31 && c < 127)
                        {
                            encoded.Append(c);
                        }
                        else
                        {
                            encoded.Append($"&#x{((int)c):X};");
                        }
                        break;
                }
            }

            return encoded.ToString();
        }

        private void CommunicationEmail_Load(object sender, EventArgs e)
        {
            staffDataTable = handler.FetchStaff();
            cmbEmailSender.DataSource = staffDataTable;
            cmbEmailSender.DisplayMember = "Email";
            cmbEmailSender.ValueMember = "Email";

            clientDataTable = handler.FetchClients();
            lstEmailRecipients.DataSource = clientDataTable;
            lstEmailRecipients.DisplayMember = "Email";
            lstEmailRecipients.ValueMember = "Email";
        }

        private void btnEmailBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
