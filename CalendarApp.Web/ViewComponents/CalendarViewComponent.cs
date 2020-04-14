using CalendarApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalendarApp.Web.ViewComponents
{
    public class CalendarViewComponent:ViewComponent
    {

        

       
        private CalMonthViewModel BuildModel(int month,int year)
        {
            var calViewModel = new CalMonthViewModel();
            var firstDay = new DateTime(year, month, 1);

            var today = DateTime.Now;

            
            
            calViewModel.Month = firstDay.ToString("MMM,yyyy", CultureInfo.InvariantCulture);
            calViewModel.Year = year;
            calViewModel.FirstDayIndex = (int)firstDay.DayOfWeek;
            var daysInMonth = DateTime.DaysInMonth(year, month);

            var calRow = new CalDayRow();
            calViewModel.Days.Add(calRow);
            var initialIndex = calViewModel.FirstDayIndex;


            for (int i = 1; i <= daysInMonth; i++)
            {
                calRow.Cells[initialIndex].Day = i.ToString();

                if(today.Year == year  && today.Month == month)
                {
                    if(today.Day == i)
                    {
                        calRow.Cells[initialIndex].ClassName = "table-primary";
                    }
                }
                if(initialIndex == 6)
                {
                    initialIndex = 0;
                    calRow = new CalDayRow();
                    calViewModel.Days.Add(calRow);
                }
                else
                {
                    initialIndex++;
                }
               
            }

            return calViewModel;
         
        }
        public IViewComponentResult Invoke(int month,int year)
        {

            return View(BuildModel(month,year));
        }

    }
}
