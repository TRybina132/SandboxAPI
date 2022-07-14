using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ServiceRate { get; set; }
        public int PriceRate { get; set; }
        public int SupportRate { get; set; }
        public string? Suggestions { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
