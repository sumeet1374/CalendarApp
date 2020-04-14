using CalendarApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Service
{
    public interface IAccountService
    {
        AppUser Login(string userName, string password);
        void Register(AppUser user);

        void ChangePassword(string userName, string newPassword);

        bool UserNameExists(string userName);
       
        List<AppRole> GetRoleList();

    }
}
