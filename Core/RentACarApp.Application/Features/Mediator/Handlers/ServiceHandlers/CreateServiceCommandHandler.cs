using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.ServiceCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<RentACarApp.Domain.Entities.Services> _repository;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IRepository<Domain.Entities.Services> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<RentACarApp.Domain.Entities.Services>(request);
            await _repository.CreateAsync(value);
        }
    }
}
