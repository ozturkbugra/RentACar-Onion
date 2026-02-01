using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentACarApp.Application.Features.Mediator.Results.SocialMediaResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>();
            CreateMap<SocialMedia, GetSocialMediaQueryResult>();
            CreateMap<CreateSocialMediaCommand, SocialMedia>();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>();
        }
    }
}
