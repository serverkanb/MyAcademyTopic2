using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class FAQManager : GenericManager<FAQ>, IFAQService
    {
        public FAQManager(IGenericDal<FAQ> genericDal) : base(genericDal)
        {
        }
    }
}
