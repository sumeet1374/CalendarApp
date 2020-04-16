using CalendarApp.Model;
using CalendarApp.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalendarApp.Web.ViewComponents
{
    public class EventAdminListViewComponent:ViewComponent
    {
        private IEventAdminService _eventAdminService;

        public EventAdminListViewComponent(IEventAdminService eventAdminService)
        {
            _eventAdminService = eventAdminService;
        }

        public IViewComponentResult Invoke(EventType eventType, DateTime startDate, DateTime endDate)
        {
            return View();
        }
    }
}
