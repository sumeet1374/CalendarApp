using CalendarApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Web.Models
{
    public class AppUserRegistrationViewModel
    {
        private const string VAL_FIRST_NAME_IS_REQUIRED = "Please enter First Name.";
        private const string VAL_INVALID_FIRST_NAME = "Invalid First Name";
        private const string VAL_LAST_NAME_IS_REQUIRED = "Please enter Last Name";
        private const string VAL_INVALID_LAST_NAME = "Invalid Last Name";

        private const string VAL_INVALID_EMAIL = "Invalid Email";
        private const string VAL_USERNAME_IS_REQUIRED = "Please enter User Name";
        private const string VAL_INVALID_USERNAME = "UserName can start with letter and it can have number or underscore.";
        private const string VAL_PASSWORD_IS_REQUIRED = "Please enter Password";
        private const string VAL_INVALID_PASSWORD = "Password should atleast contain 1 upper case letter, 1 lowercase letter, 1 number and 1 special character and it should be of minimum 8 characters.";
        private const string VAL_CONFIRM_PASSWORD_REQUIRED = "Please enter Confirm Password.";
        private const string VAL_CONFIRM_PASSWORD_COMPARE = "Confirm Password should match with the password entered.";


        [Required(ErrorMessage = VAL_FIRST_NAME_IS_REQUIRED)]
        [RegularExpression("^[a-zA-Z]*$",ErrorMessage = VAL_INVALID_FIRST_NAME)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = VAL_LAST_NAME_IS_REQUIRED)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = VAL_INVALID_LAST_NAME)]
        public string LastName { get; set; }

  
        [EmailAddress(ErrorMessage = VAL_INVALID_EMAIL)]
        public string Email { get; set; }


        [Required(ErrorMessage = VAL_USERNAME_IS_REQUIRED)]
        [RegularExpression("^[a-zA-Z][a-zA-Z_0-9]*$",ErrorMessage = VAL_INVALID_USERNAME)]
        [Remote(action: "VerifyUserName",controller:"Account")]
        public string UserName { get; set; }

        [Required(ErrorMessage = VAL_PASSWORD_IS_REQUIRED)]
        [RegularExpression(@"^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*])(?!.*\s).*$",ErrorMessage =VAL_INVALID_PASSWORD)]
        public string Password { get; set; }

        [Required(ErrorMessage = VAL_CONFIRM_PASSWORD_REQUIRED)]
        [Compare("Password",ErrorMessage = VAL_CONFIRM_PASSWORD_COMPARE)]
        public string ConfirmPassword { get; set; }


        [Required]
        public int RoleId{ get; set; }

        public List<AppRole> RoleList { get; set; }
       


    }
}
