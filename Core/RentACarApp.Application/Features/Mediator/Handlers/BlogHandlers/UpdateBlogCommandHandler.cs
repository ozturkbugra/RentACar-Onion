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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            if (value != null)
            {
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception("Blog not found");
            }
        }
    }
}
