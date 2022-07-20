using Core.Entities;
using Core.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        // ᓚᘏᗢ Use MailKit


        const string address = "vetclinicmanager222@gmail.com";
        const string protocol = "smtp.gmail.com";
        const int port = 587;

        public EmailService()
        {
        }

        public async Task Send(EmailMessage message)
        {

            //System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
            //MyMailMessage.From = new System.Net.Mail.MailAddress("vetclinicmanager222@gmail.com");
            //MyMailMessage.To.Add(email);// Mail would be sent to this address
            //MyMailMessage.Subject = "Feedback Form";

            //MyMailMessage.Body = "yey";
            //System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            //SMTPServer.Port = 587;
            //SMTPServer.Credentials = new System.Net.NetworkCredential("vetclinicmanager222@gmail.com", "oxoelgyyqeyvyxzo");
            //SMTPServer.EnableSsl = true;
            //try
            //{

            //    SMTPServer.Send(MyMailMessage);
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);

            //}

            var createdMessage = new MimeMessage();
            createdMessage.From.Add(new MailboxAddress("Vet clinic", address));
            createdMessage.To.Add(MailboxAddress.Parse(message.Recipient));

            createdMessage.Subject = message.Subject;

            createdMessage.Body = new TextPart(message.Format)
            {
                Text = message.Body
            };


            SmtpClient client = new SmtpClient();

            try
            {
                await client.ConnectAsync(protocol, port,SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(address, "oxoelgyyqeyvyxzo");
                await client.SendAsync(createdMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
