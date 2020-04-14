using System;
using System.Collections.Generic;

namespace CalendarApp.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }

        public int RoleId { get; set; }
        public virtual AppRole Role { get; set; }

        public bool Deleted { get; set; }
    }
}
