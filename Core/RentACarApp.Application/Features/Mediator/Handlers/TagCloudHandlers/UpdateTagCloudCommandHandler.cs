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
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudID);
            if (value == null)
                throw new Exception("Tag Cloud not found");
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
