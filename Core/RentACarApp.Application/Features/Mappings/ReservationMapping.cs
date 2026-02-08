using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.ReservationCommands;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class ReservationMapping : Profile
    {
        public ReservationMapping()
        {
            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}
