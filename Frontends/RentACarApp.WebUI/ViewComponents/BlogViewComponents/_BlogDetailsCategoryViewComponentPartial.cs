using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
