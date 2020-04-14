using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalendarApp.Model;
using CalendarApp.Service;
using CalendarApp.Web.LocalServices;
using CalendarApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string INVALID_LOGIN = "Invalid User Name or Password.";
        private readonly IAccountService _accountService;




        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Layout"] = "_UnAuthLayout";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserViewModel user)
        {
            ViewData["Layout"] = "_UnAuthLayout";
            if (ModelState.IsValid)
            {
                bool isValid = true;
                try
                {
                    var appUser = _accountService.Login(user.UserName, user.Password);
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, appUser.UserName),
                            new Claim("FullName",$"{appUser.FirstName} {appUser.LastName}"),
                            new Claim(ClaimTypes.Role, appUser.Role.Name)
                        };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                   
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties());
                   
                }
                catch (ValidationException)
                {
                    isValid = false;
                    ModelState.AddModelError("GlobalErrorMessage", INVALID_LOGIN);
                }

                if(isValid)
                   return RedirectToAction("Index", "Home");
            }
       
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Layout"] = "_UnAuthLayout";
            ViewData[AppConstants.NO_MENU] = true; // Set this value to not create menu
            ViewData["RoleList"] = _accountService.GetRoleList();
            return View();

        }

        [HttpPost]
        public IActionResult Register(AppUserRegistrationViewModel user)
        {
            ViewData["Layout"] = "_UnAuthLayout";
            if (ModelState.IsValid)
            {
                _accountService.Register(user.GetUser());
                return View("_Confirmation");
                   
            }
            return View(user);

        }

        
        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyUserName(string userName)
        {
            if(_accountService.UserNameExists(userName))
            {
                return Json($"User Name {userName} is already in use.");
            }

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}