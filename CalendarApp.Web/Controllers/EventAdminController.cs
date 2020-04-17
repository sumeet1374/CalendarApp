using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Web.Controllers
{
    public class EventAdminController : Controller
    {
        [HttpGet]
        [Authorize(Policy = AppConstants.EVENT_MANAGER_POLICY) ]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = AppConstants.EVENT_MANAGER_POLICY)]
        public IActionResult Create()
        {
            return View();
        }
    }
}