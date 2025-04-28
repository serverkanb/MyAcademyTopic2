using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;

namespace Topic.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly TopicContext _context;
  

        public GenericRepository(TopicContext context)
        {
            _context = context;
 
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().FirstOrDefault(filter); ;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
