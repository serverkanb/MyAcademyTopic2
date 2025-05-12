using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.EntityLayer.Entities
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } = "USER";
        public DateTime? SubscribedDate { get; set; } = DateTime.Now;
    }
}
