using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.CarCommands;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Domain.Entities;

namespace RentACarApp.Application.Features.Mappings
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car, GetCarQueryResult>();
            CreateMap<Car, GetCarByIdQueryResult>();
            CreateMap<CreateCarCommand, Car>();
            CreateMap<UpdateCarCommand, Car>();
            CreateMap<Car, GetCarWithBrandQueryResult>()
                        .ForMember(dest => dest.BrandName,
                                   opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Car, GetLast5CarsWithBrandQueryResult>()
                        .ForMember(dest => dest.BrandName,
                                   opt => opt.MapFrom(src => src.Brand.Name));

            CreateMap<Car, GetCarByIdWithBrandQueryResult>()
                        .ForMember(x => x.BrandName,
                                   y => y.MapFrom(z=> z.Brand.Name));
           
        }
    }
}
