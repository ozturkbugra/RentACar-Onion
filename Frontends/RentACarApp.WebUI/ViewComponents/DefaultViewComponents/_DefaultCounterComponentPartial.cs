using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCounterComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        } 
    }
}
