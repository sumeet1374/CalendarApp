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
            menuList.Add(new MenuItem() { Title = "Home", Controller = "Home", Action = "Index" });
            menuList.Add(new MenuItem() { Title = "Privacy", Controller = "Home", Action = "Privacy" });
            return menuList;
        }
    }
}
