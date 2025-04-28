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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal,ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> TActiveCategories()
        {
            return _categoryDal.GetActiveCategories();
        }
    }
}
