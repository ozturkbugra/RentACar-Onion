using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarFeatureList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
    }
}
