using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.PricingCommands;
using RentACarApp.Application.Features.Mediator.Commands.ServiceCommands;
using RentACarApp.Application.Features.Mediator.Results.PricingResults;
using RentACarApp.Application.Features.Mediator.Results.ServiceResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<RentACarApp.Domain.Entities.Services, GetServiceQueryResult>();
            CreateMap<RentACarApp.Domain.Entities.Services, GetServiceByIdQueryResult>();
            CreateMap<CreateServiceCommand, RentACarApp.Domain.Entities.Services>();
            CreateMap<UpdateServiceCommand, RentACarApp.Domain.Entities.Services>();
        }
    }
}
