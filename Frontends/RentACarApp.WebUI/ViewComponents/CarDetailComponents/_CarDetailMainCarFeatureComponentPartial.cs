using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.ViewComponents.CarDetailComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
