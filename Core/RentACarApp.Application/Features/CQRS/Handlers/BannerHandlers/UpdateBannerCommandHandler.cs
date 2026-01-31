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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBannerCommand command) 
        {
            var value = await _repository.GetByIdAsync(command.BannerID);
            _mapper.Map(command, value);
            await _repository.UpdateAsync(value);
        }
    }
}
