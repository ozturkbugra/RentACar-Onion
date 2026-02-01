using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        private readonly IMapper _mapper;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<FooterAddress>(request);
            await _repository.CreateAsync(value);
        }
    }
}
