using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.CQRS.Commands.CarCommands;
using RentACarApp.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarApp.Application.Features.CQRS.Queries.CarQueries;
using RentACarApp.Application.Features.Mediator.Queries.StatisticQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;
        private readonly GetCarsWithPricingQueryHandler _getCarsWithPricingQueryHandler;

        private readonly IMediator _mediator;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler, GetCarsWithPricingQueryHandler getCarsWithPricingQueryHandler, IMediator mediator)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
            _getCarsWithPricingQueryHandler = getCarsWithPricingQueryHandler;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CarById(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car bilgisi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car bilgisi güncellendi");
        }


        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values = await _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarsWithPricing")]
        public async Task<IActionResult> GetCarsWithPricing()
        {
            var values = await _getCarsWithPricingQueryHandler.Handle();
            return Ok(values);
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

    }
}
