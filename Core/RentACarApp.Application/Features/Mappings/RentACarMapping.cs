using AutoMapper;
using RentACarApp.Application.Features.Mediator.Results.RentACarResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class RentACarMapping : Profile
    {
        public RentACarMapping()
        {
            CreateMap<RentACar, GetRentACarQueryResult>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
            .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.Car.BrandID))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
            .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Car.CarPricings
                .Where(x => x.Pricing.Name == "Günlük")
                .Select(y => y.Amount)
                .FirstOrDefault()));
        }
    }
}
