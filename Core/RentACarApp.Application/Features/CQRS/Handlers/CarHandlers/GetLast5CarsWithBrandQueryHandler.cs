using AutoMapper;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle()
        {
            var value = await _repository.GetLast5CarsWithBrandAsync();
            return _mapper.Map<List<GetLast5CarsWithBrandQueryResult>>(value);
        }
    }
}
