using CalendarApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Service
{
    public interface IEventAdminService
    {
        public List<EventSchedule> FindSchedules(EventType eventType, DateTime startDate, DateTime endDate,int pageNumber,int pageSize);

        public void CreateEvent(EventSchedule schedule);

        public void UpdateEven(EventSchedule schedule);

        public void DeleteEvent(EventSchedule schedule);


    }
}
