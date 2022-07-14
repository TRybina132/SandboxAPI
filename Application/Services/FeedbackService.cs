using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Core.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        IFeedbackRepository repository;

        public FeedbackService(IFeedbackRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IList<Feedback>> GetAll() =>
            await repository.QueryAsync(
                asNoTracking: true,
                include: query =>
                    query.Include(feedback => feedback.User));

        public Task<IList<Feedback>> GetAll(FeedbackParameters parameters) =>
            repository.QueryAsync(
                asNoTracking: true,
                include: query =>
                    query.Include(feedback => feedback.User),
                take: parameters.PageSize,
                skip: (parameters.PageNumber - 1) * parameters.PageSize);

        public async Task Add(Feedback feedback)
        {
            await repository.InsertAsync(feedback);
            await repository.SaveChangesAsync();
        }
    }
}
