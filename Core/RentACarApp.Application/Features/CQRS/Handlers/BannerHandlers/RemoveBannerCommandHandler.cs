using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.BannerCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public RemoveBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
