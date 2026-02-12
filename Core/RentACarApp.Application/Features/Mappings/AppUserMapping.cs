using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.AppUserCommands;
using RentACarApp.Application.Features.Mediator.Results.AppUserResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping() {

            CreateMap<AppUser, GetCheckAppUserQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppUserID))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AppRole.Name))
                .ForMember(dest => dest.IsExist, opt => opt.MapFrom(src => true));

            CreateMap<CreateAppUserCommand, AppUser>();

        }
    }
}
