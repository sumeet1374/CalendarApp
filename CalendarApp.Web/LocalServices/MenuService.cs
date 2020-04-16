using CalendarApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web.LocalServices
{
    public class MenuService : IMenuService
    {
        
        public List<MenuItem> GetMenus()
        {
            var menuList = new List<MenuItem>();
            var home = new MenuItem(AppConstants.ADMIN_ROLE, AppConstants.ORGANIZER_ROLE, AppConstants.PARTICIPANT_ROLE) { Title = "Home", Controller = "Home", Action = "Index" };
            menuList.Add(home);
            // Organize
            var org = new MenuItem(AppConstants.ADMIN_ROLE, AppConstants.ORGANIZER_ROLE,AppConstants.PARTICIPANT_ROLE) { Title = "Organize", Controller = "", Action = "" ,Id="Org" ,};
            var events = new MenuItem(AppConstants.ADMIN_ROLE, AppConstants.ORGANIZER_ROLE) { Title = "Events", Controller = "Event", Action = "Index" };
            var tasks = new MenuItem(AppConstants.ADMIN_ROLE, AppConstants.ORGANIZER_ROLE) { Title = "Tasks", Controller = "Task", Action = "Index" };
            var reminders = new MenuItem(AppConstants.ADMIN_ROLE, AppConstants.ORGANIZER_ROLE,AppConstants.PARTICIPANT_ROLE) { Title = "Reminders", Controller = "Reminder", Action = "Index" };
            org.SubMenus.Add(events);
            org.SubMenus.Add(tasks);
            org.SubMenus.Add(reminders);
            menuList.Add(org);
            var admin = new MenuItem(AppConstants.ADMIN_ROLE) { Title = "Admin", Controller = "", Action = "" ,Id="Admin"};
            var userManagement = new MenuItem(AppConstants.ADMIN_ROLE) { Title = "Users", Controller = "Account", Action = "Users" };
            admin.SubMenus.Add(userManagement);
            menuList.Add(admin);
            return menuList;
        }
    }
}
