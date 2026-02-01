using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.LocationCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Location>(request);
            await _repository.CreateAsync(value);
        }
    }
}
