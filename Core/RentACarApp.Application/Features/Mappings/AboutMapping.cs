using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.AboutCommands;
using RentACarApp.Application.Features.CQRS.Results.AboutResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Application.Features.Mappings
{
    public class AboutMapping: Profile
    {
        public AboutMapping()
        {
            CreateMap<About, GetAboutQueryResult>();
            CreateMap<About, GetAboutByIdQueryResult>();
            CreateMap<CreateAboutCommand, About>();
            CreateMap<UpdateAboutCommand, About>();
        }
    }
}
