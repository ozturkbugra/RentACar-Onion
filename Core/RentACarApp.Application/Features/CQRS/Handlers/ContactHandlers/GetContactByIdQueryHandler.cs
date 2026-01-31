using AutoMapper;
using RentACarApp.Application.Features.CQRS.Queries.ContactQueries;
using RentACarApp.Application.Features.CQRS.Results.ContactResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            return _mapper.Map<GetContactByIdQueryResult>(value);
        }
    }
}
