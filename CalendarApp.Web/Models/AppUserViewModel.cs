using CalendarApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarApp.Web.Models
{
    public class AppUserViewModel
    {
        private const string USER_NAME_IS_REQUIRED = "User Name is required";
        private const string PASSWORD_IS_REQUIRED = "Password is required.";

        [Required(ErrorMessage =USER_NAME_IS_REQUIRED)]
        public string UserName { get; set; }

        [Required(ErrorMessage = PASSWORD_IS_REQUIRED)]
        public string Password { get; set; }

        public string GlobalErrorMessage { get; set; }


    }
}
