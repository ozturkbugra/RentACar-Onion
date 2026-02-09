using AutoMapper;
using RentACarApp.Application.Features.Mediator.Results.CarFeatureResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class CarFeatureMapping : Profile
    {
        public CarFeatureMapping() {

            CreateMap<CarFeature, GetCarFeatureByCarIdQueryResult>()
            .ForMember(dest => dest.FeatureName,
                                   opt => opt.MapFrom(src => src.Feature.Name));

        }
    }
}
