using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Db
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Get();
    }
}
