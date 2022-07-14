using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Passport
    {
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateOfIssue { get; set; }

        public User User { get; set; }
    }
}
