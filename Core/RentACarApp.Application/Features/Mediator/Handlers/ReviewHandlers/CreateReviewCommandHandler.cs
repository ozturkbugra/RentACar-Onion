using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.LocationCommands;
using RentACarApp.Application.Features.Mediator.Commands.ReviewCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Review>(request);
            await _repository.CreateAsync(values);
        }

    }
}
