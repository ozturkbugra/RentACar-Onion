using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarApp.Application.Features.Mediator.Results.FooterAddressResult;
using RentACarApp.Domain.Entities;

namespace RentACarApp.Application.Features.Mappings
{
    public class FooterAddressMaping : Profile
    {
        public FooterAddressMaping()
        {
            CreateMap<FooterAddress, GetFooterAddressQueryResult>();
            CreateMap<FooterAddress, GetFooterAddressByIdQueryResult>();
            CreateMap<CreateFooterAddressCommand, FooterAddress>();
            CreateMap<UpdateFooterAddressCommand, FooterAddress>();
        }
    }
}
