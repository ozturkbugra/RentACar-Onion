using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.CarDtos;

namespace RentACarApp.WebUI.ViewComponents.CarDetailComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(ResultCarWithBrandDto values)
        {
            return View(values);
        }
    }
}
