using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web.Models
{
    public class CalMonthViewModel
    {
        public string Month { get; set; }
        public int Year { get; set; }

        public int FirstDayIndex { get; set; }

        public List<CalDayRow> Days { get; set; } = new List<CalDayRow>();

    }

    public class CalDayRow
    {
        public CalDayCell[] Cells { get; set; } = new CalDayCell[7];

        public CalDayRow()
        {
            
            for(int i = 0; i < 7; i++)
            {
                Cells[i] = new CalDayCell();
            }
        }
    }

    public class CalDayCell 
    {
        public string Day { get; set; }
        public string ClassName { get; set; }
    }
   
}
