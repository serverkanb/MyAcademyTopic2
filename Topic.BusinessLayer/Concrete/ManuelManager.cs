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
    public class ManuelManager : GenericManager<Manuel>, IManuelService
    {
        public ManuelManager(IGenericDal<Manuel> genericDal) : base(genericDal)
        {
        }
    }
}
