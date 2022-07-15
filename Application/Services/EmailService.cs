using Core.Interfaces.Services;
using MimeKit;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        // ᓚᘏᗢ Use MailKit


        const string address = "vetClinic224466@gmail.com";

        public EmailService()
        {
        }

        public async Task Send(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Vet clinic", address));
            message.To.Add(new MailboxAddress("PotatoI9", email));

            message.Subject = "Please, tell us what wrong";

            message.Body = new TextPart("plain")
            {
                Text = "You have left feedback that you aren't"
            };
        }
    }
}
