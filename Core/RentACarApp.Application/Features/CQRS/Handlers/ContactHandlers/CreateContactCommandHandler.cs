using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.ContactCommads;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepository<Contact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var value = _mapper.Map<Contact>(command);
            await _contactRepository.CreateAsync(value);
        }
    }
}
