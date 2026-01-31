using AutoMapper;
using RentACarApp.Application.Features.CQRS.Commands.BrandCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _Repository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _Repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            var value = _mapper.Map<Brand>(command);
            await _Repository.CreateAsync(value);
        }

    }
}
