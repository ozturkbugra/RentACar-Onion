using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.CQRS.Commands.AboutCommands;
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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorID);
            if (value != null)
            {
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception("Author not found");
            }

        }
    }
}
