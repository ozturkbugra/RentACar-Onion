using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.CommentCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Comment>(request);
             await _repository.CreateAsync(value);
        }
    }
}
