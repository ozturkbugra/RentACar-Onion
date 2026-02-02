using AutoMapper;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarsWithPricingQueryHandler
    {
        private readonly ICarPricingRepository _repository;

        public GetCarsWithPricingQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsWithPricingQueryResult>> Handle()
        {
            var values = await _repository.GetCarsWithPricingsAsync();

            var result = values.Select(x => new GetCarsWithPricingQueryResult
            {
                CarID = x.CarID,
                BrandID = x.Car.BrandID,
                BrandName = x.Car.Brand?.Name,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
                KM = x.Car.KM,
                Transmission = x.Car.Transmission,
                Seat = x.Car.Seat,
                Luggage = x.Car.Luggage,
                FuelType = x.Car.FuelType,
                BigImageUrl = x.Car.BigImageUrl,

                PricingName = x.Pricing?.Name,
                PricingAmount = x.Amount.ToString()
            }).ToList();

            return result;
        }
    }
}
