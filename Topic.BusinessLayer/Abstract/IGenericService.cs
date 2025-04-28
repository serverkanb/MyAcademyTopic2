using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();

        List<T> TGetFilteredList(Expression<Func<T, bool>> filter);

        T TGetByFilter(Expression<Func<T, bool>> filter);

        T TGetById(int id);

        void TCreate(T entity);

        void TUpdate(T entity);

        void TDelete(int id);
    }
}
