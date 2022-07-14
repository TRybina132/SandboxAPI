using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeliveryService : IDeliveryService
    {
        IDeliveryRepository repository;

        public DeliveryService(IDeliveryRepository repository) =>
            this.repository = repository;

        public async Task<IList<Delivery>> GetAll() =>
            await repository.QueryAsync(include: query =>
                query.Include(delivery => delivery.Items), asNoTracking: true);

        public async Task AddDelivery(Delivery delivery)
        {
            await repository.InsertAsync(delivery);
            await repository.SaveChangesAsync();
        }
    }
}
