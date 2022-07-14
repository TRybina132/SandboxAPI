using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public int DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
    }
}
