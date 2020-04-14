using CalendarApp.Model;
using CalendarApp.Web.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CalendarApp.Web.LocalServices
{
    public static class Utils
    {


       public static AppUser GetUser(this  AppUserRegistrationViewModel user)
        {
            var appUser = new AppUser();
            appUser.UserName = user.UserName;
            appUser.Password = user.Password;
            appUser.FirstName = user.FirstName;
            appUser.LastName = user.LastName;
            appUser.Email = user.Email;
            appUser.RoleId = user.RoleId;

            return appUser;

        }
    }
}
