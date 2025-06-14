﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;

namespace Topic.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TCreate(T entity)
        {
            _genericDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _genericDal.Delete(id);
        }

        public T TGetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _genericDal.GetByFilter(filter);
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> TGetFilteredList(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _genericDal.GetFilteredList(filter);
        }

        public List<T> TGetList()
        {
            return _genericDal.GetList();
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
