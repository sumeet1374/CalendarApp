using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Model
{
    public class AppRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public virtual List<AppUser> Users { get; set; }
    }
}
