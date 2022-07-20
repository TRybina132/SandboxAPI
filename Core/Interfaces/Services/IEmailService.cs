using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEmailService
    {
        public Task Send(EmailMessage message);
    }
}
