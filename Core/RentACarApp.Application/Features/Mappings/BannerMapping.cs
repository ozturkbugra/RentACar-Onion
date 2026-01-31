using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.BannerCommands;
using RentACarApp.Application.Features.CQRS.Results.BannerResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class BannerMapping: Profile
    {
        public BannerMapping()
        {
            CreateMap<Banner, GetBannerQueryResult>();
            CreateMap<Banner, GetBannerByIdQueryResult>();
            CreateMap<CreateBannerCommand, Banner>();
            CreateMap<UpdateBannerCommand, Banner>();
        }
    }
}
