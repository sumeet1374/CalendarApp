using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Db
{
    public interface IUnitOfWork:IDisposable
    {
        T GetContext<T>() where T : class;

        void Commit();
    }
}
