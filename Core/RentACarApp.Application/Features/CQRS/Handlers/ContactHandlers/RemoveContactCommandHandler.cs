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
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public RemoveContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(RemoveContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.Id);
            if (contact != null)
            {
                await _repository.RemoveAsync(contact);
            }
        }
    }
}
