using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        readonly IEmailService service;

        public EmailController(IEmailService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task SendEmail([FromBody] EmailMessage email) =>
            await service.Send(email);
    }
}
