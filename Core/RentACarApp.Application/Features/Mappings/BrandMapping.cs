using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.BrandCommands;
using RentACarApp.Application.Features.CQRS.Results.BrandResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class BrandMapping : Profile
    {
        public BrandMapping() {
            CreateMap<Brand, GetBrandQueryResult>();
            CreateMap<Brand, GetBrandByIdQueryResult>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>();

        }
    }
}
