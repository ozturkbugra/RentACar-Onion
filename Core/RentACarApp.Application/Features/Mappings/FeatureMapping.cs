using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.FeatureCommands;
using RentACarApp.Application.Features.Mediator.Results.FeatureResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, GetFeatureQueryResult>();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
            CreateMap<CreateFeatureCommand, Feature>();
            CreateMap<UpdateFeatureCommand, Feature>();
        }
    }
}
