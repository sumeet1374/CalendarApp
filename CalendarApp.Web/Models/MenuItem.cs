using System.Collections.Generic;

namespace CalendarApp.Web.Models
{
    public class MenuItem
    {
        public MenuItem()
        {

        }

        public MenuItem(params string[] roles)
        {
            Roles.AddRange(roles);
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }

        public string Action { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public List<MenuItem> SubMenus { get; set; } = new List<MenuItem>();

        public void AddRoles(params string[] roles)
        {
            Roles.AddRange(roles);
        }
    }
}
