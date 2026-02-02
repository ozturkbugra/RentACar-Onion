using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.BlogCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Blog>(request);
            await _repository.CreateAsync(value);
        }
    }
}
