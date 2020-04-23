using CalendarApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Service
{
    public interface IEventAdminService
    {
         List<EventSchedule> FindSchedules(EventType eventType, DateTime startDate, DateTime endDate,int pageNumber,int pageSize);

         void CreateEvent(EventSchedule schedule);

         void UpdateEvent(EventSchedule schedule);

         void DeleteEvent(EventSchedule schedule);

         bool IsOverlappingEvent(string userName,DateTime date,string startTime,string endTime);
      


    }
}
