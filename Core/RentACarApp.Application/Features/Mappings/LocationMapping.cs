using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarApp.Application.Features.Mediator.Commands.LocationCommands;
using RentACarApp.Application.Features.Mediator.Results.FooterAddressResult;
using RentACarApp.Application.Features.Mediator.Results.LocationResult;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class LocationMapping  : Profile
    {
        public LocationMapping()
        {
            CreateMap<Location, GetLocationQueryResult>();
            CreateMap<Location, GetLocationByIdQueryResult>();
            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>();
        }
    }
}
