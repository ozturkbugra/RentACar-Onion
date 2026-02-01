using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.PricingCommands;
using RentACarApp.Application.Features.Mediator.Results.PricingResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class PricingMapping:Profile
    {
        public PricingMapping()
        {
            CreateMap<Pricing, GetPricingQueryResult>();
            CreateMap<Pricing, GetPricingByIdQueryResult>();
            CreateMap<CreatePricingCommand, Pricing>();
            CreateMap<UpdatePricingCommand, Pricing>();
        }
    }
}
