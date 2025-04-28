using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();

        List<T> GetFilteredList(Expression<Func<T, bool>> filter);

        T GetByFilter(Expression<Func<T, bool>> filter);

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
        
        
    }
}
