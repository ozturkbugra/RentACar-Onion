using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.ContactCommads;
using RentACarApp.Application.Features.CQRS.Results.ContactResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class ContactMapping: Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, GetContactQueryResult>();
            CreateMap<Contact, GetContactByIdQueryResult>();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();
        }
    }
}
