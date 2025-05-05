using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DTOLayer.Dtos.BlogDtos
{
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
    }
}
