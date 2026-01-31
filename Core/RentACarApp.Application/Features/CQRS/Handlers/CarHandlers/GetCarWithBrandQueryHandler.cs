using AutoMapper;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var value = await _repository.GetCarsListWithBrandAsync();
            return _mapper.Map<List<GetCarWithBrandQueryResult>>(value);
        }
    }
}
