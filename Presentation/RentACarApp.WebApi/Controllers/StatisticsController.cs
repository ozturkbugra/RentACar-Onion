using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.Mediator.Queries.StatisticQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("AvgCarPricingDaily")]
        public async Task<IActionResult> AvgCarPricingDaily()
        {
            var values = await _mediator.Send(new AvgCarPricingDailyQuery());
            return Ok(values);
        }

        [HttpGet("MaxCarByBrand")]
        public async Task<IActionResult> MaxCarByBrand()
        {
            var values = await _mediator.Send(new MaxCarByBrandQuery());
            return Ok(values);
        }

        [HttpGet("BrandCount")]
        public async Task<IActionResult> BrandCount()
        {
            var values = await _mediator.Send(new BrandCountQuery());
            return Ok(values);
        }





    }
}
