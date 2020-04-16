using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CalendarApp.Db
{
    public interface IRepository<T>
    {
        T GetById(object id);
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> where);

        T GetSingle(Expression<Func<T, bool>> where);

        PagedResult<T> GetWithPaging(Expression<Func<T, bool>> where,int pageNumber,int pageSize);
        List<T> Get(Func<object, List<T>> query);  // Can create custom query first parameter could db DbSet<T>

        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);

        IUnitOfWork Context {  get; set; }


    }
}
 