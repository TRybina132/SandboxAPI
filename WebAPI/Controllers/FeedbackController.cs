using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Parameters;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        readonly IFeedbackService service;

        readonly IMapper<Feedback, CreateFeedbackViewModel> createMapper;

        public FeedbackController(
            IFeedbackService service,
            IMapper<Feedback, CreateFeedbackViewModel> createMapper)
        {
            this.service = service;
            this.createMapper = createMapper;
        }

        [HttpGet]
        public async Task<IList<Feedback>> GetAll([FromQuery] FeedbackParameters parameters) =>
            await service.GetAll(parameters);

        //[HttpGet]
        //public async Task<IList<Feedback>> GetAll() =>
        //    await service.GetAll();

        [HttpPost]
        public async Task AddFeedback([FromBody] CreateFeedbackViewModel feedback) =>
            await service.Add(createMapper.Map(feedback));
    }
}
