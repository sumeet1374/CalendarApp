using CalendarApp.Web.LocalServices;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApp.Web.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IMenuService _menuService;


        public MenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public IViewComponentResult Invoke()
        {
         
            return View(_menuService.GetMenus());

           
        }
    }
}
