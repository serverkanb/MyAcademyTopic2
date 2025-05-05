using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.EntityLayer.Entities
{
    public  class FAQ
    {
        public int FaqId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
