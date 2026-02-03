using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.TagCloudCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<TagCloud>(request);
            await _repository.CreateAsync(value);
        }
    }
}
