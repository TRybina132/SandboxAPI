using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/delivery")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        readonly IDeliveryService service;

        public DeliveryController(IDeliveryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Delivery>> GetAll() =>
            await service.GetAll();

        [HttpPost]
          public async Task Add([FromBody] Delivery delivery) => 
            await service.AddDelivery(delivery);
    }
}
