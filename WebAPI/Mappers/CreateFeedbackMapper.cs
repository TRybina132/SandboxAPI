using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Mappers
{
    public class CreateFeedbackMapper : IMapper<Feedback, CreateFeedbackViewModel>
    {
        public Feedback Map(CreateFeedbackViewModel viewModel) =>
            new Feedback
            {
                UserId = viewModel.UserId,
                Email = viewModel.Email,
                ServiceRate = viewModel.PriceRate,
                PriceRate = viewModel.PriceRate,
                SupportRate = viewModel.SupportRate,
                Suggestions = viewModel.Suggestions
            };

        public CreateFeedbackViewModel Map(Feedback viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
