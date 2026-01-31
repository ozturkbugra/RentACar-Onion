using AutoMapper;
using RentACarApp.Application.Features.CQRS.Queries.BrandQueries;
using RentACarApp.Application.Features.CQRS.Results.BrandResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            return _mapper.Map<GetBrandByIdQueryResult>(value);
        }
    }
}
