using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSidebarSearchBoxComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
