using Core.Entities;
using Core.Interfaces.Repository;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DeliveryRepository : Repository<Delivery>,IDeliveryRepository
    {
        public DeliveryRepository(SandboxContext sandboxContext) : base(sandboxContext)
        {
        }
    }
}
