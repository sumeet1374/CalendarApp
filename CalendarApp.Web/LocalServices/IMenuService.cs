using CalendarApp.Web.Models;
using System.Collections.Generic;

namespace CalendarApp.Web.LocalServices
{
    public interface IMenuService
    {
        List<MenuItem> GetMenus();
    }
}
