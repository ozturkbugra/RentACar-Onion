using AutoMapper;
using MediatR;
using RentACarApp.Application.Enums;
using RentACarApp.Application.Features.Mediator.Commands.AppUserCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<AppUser>(request);
            values.AppRoleID = (int)RoleTypes.Visitor;
            await _repository.CreateAsync(values);
           
        }
    }
}
