using CalendarApp.Db;
using CalendarApp.Model;
using CalendarApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Service
{
    public class EventAdminService : IEventAdminService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IRepository<AppUser> _userRepository;
        private IRepository<EventSchedule> _eventScheduleRepository;
        public EventAdminService(IUnitOfWorkFactory unitofWorkFactory,IRepository<AppUser> userRepository,IRepository<EventSchedule> eventScheduleRepository)
        {
            _userRepository = userRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _unitOfWorkFactory = unitofWorkFactory;
        }

        public void CreateEvent(EventSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(EventSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public List<EventSchedule> FindSchedules(EventType eventType, DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool IsOverlappingEvent(string userName, DateTime date, string startTime, string endTime)
        {
            using(var unitOfWork = _unitOfWorkFactory.Get())
            {
                _userRepository.Context = unitOfWork;
                _eventScheduleRepository.Context = unitOfWork;
                var user = _userRepository.GetSingle(x => x.UserName == userName && x.Deleted == false);
                if (user == null)
                    throw new ValidationException($"{userName} not found");
                // Find EventSchedules
                var eventStartDate = date.AppendTime(startTime);
                var eventEndDate = date.AppendTime(endTime);
                if (eventEndDate <= eventStartDate)
                    throw new ValidationException("End date should be greater than event start date.");

                var schedules = _eventScheduleRepository.Get(x => x.Organizer.Id == user.Id && ((eventStartDate <= x.StartDateTime && eventEndDate > x.StartDateTime) || (eventStartDate > x.StartDateTime && eventStartDate <= x.EndDateTime)));
                if(schedules.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public void UpdateEvent(EventSchedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
