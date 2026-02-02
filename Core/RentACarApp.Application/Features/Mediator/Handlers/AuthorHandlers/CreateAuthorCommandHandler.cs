using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.AuthorCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>

    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Author>(request);
            await _repository.CreateAsync(value);
        }
    }
}
