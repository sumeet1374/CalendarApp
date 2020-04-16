using CalendarApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CalendarApp.Db
{
    public class GenericRepository<T> : IRepository<T> where T:class 
    {
      
        public GenericRepository()
        {
            
        }

        private DbSet<T> GetDbSet()
        {
           return  (Context.GetContext<DbContext>()).Set<T>();
        }

        public void Add(T obj)
        {
            GetDbSet().Add(obj);
        }

        public void Delete(T obj)
        {
            var set = GetDbSet();
            var result = set.Find(obj);
            if(result != null)
            set.Remove(obj);
        }

        public List<T> Get(Expression<Func<T, bool>> where)
        {
            return GetDbSet().Where(where).ToList();
        }

        public List<T> Get(Func<object, List<T>> query)
        {
            return query(GetDbSet());
        }

        public List<T> GetAll()
        {
            return GetDbSet().ToList();
        }

        public T GetById(object id)
        {
            return GetDbSet().Find(id);
        }

        public void Update(T obj)
        {
            // It is assumed the the entry is going to be disconnected
            // In service better to avoid this method . Better to get the info from the context and then
            // make changes and save the data 
            (Context as DbContext).Entry(obj).State = EntityState.Modified;
            GetDbSet().Attach(obj);
        }

        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return GetDbSet().Where(where).FirstOrDefault();
        }

        public PagedResult<T> GetWithPaging(Expression<Func<T, bool>> where, int pageNumber, int pageSize)
        {
            var pageResult = new PagedResult<T>();
            var count = GetDbSet().Where(where).Count();
            if (count < (pageNumber * pageSize))
                throw new ValidationException("Records less than page number");

            var numbrOfPages = count / pageSize;

            if (count % pageSize > 0)
                numbrOfPages += 1;
            pageResult.NumberOfPages = numbrOfPages;
             var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            pageResult.Result = GetDbSet().Where(where).Skip(skip).Take(take).ToList();
            pageResult.RowCount = count;
            return pageResult;
        }

        public IUnitOfWork Context {  get; set; }

       
    }
}
