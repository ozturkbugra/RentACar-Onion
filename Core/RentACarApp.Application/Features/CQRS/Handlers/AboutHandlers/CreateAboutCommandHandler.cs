using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.AboutCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            var entity = _mapper.Map<About>(command);
            await _repository.CreateAsync(entity);
        }

    }
}
