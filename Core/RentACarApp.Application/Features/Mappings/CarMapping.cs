using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.CarCommands;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
