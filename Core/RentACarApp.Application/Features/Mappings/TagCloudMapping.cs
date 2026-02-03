using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.TagCloudCommands;
using RentACarApp.Application.Features.Mediator.Results.TagCloudResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class TagCloudMapping : Profile
    {
        public TagCloudMapping()
        {
            CreateMap<TagCloud, GetTagCloudQueryResult>();
            CreateMap<TagCloud, GetTagCloudByIdQueryResult>();
            CreateMap<CreateTagCloudCommand, TagCloud>();
            CreateMap<UpdateTagCloudCommand, TagCloud>();
        }
    }
}
