using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Feedback>? Feedbacks { get; set; }
        public ICollection<UserAchievement>? UserAchievements { get; set; }
        public Passport Passport { get; set; }
    }
}
