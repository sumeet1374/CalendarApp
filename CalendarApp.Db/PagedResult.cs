using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Db
{
    public class PagedResult<T>
    {
        public int RowCount { get; set; }

        public int NumberOfPages { get; set; }
        public List<T> Result { get; set; }
    }
}
