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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<RentACarApp.Domain.Entities.Services> _repository;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IRepository<Domain.Entities.Services> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServicesID);
            if (value == null)
                throw new Exception("Services bulunamadı");
            _mapper.Map(request, value);
           await _repository.UpdateAsync(value);
        }
    }
}
