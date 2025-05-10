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
    public class SubscriberManager : GenericManager<Subscriber>, ISubscriberService
    {
        public SubscriberManager(IGenericDal<Subscriber> genericDal) : base(genericDal)
        {
        }
    }
}
