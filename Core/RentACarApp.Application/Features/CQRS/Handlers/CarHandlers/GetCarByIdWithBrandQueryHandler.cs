using AutoMapper;
using RentACarApp.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        public GetCarByIdWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarByIdWithBrandQueryResult> Handle(GetCarByIdWithBrandQuery query)
        {
            var value = await _repository.GetCarByIdWithBrandAsync(query.Id);
            if (value == null)
            {
                throw new Exception("Car bulunamadı");
            }
            return _mapper.Map<GetCarByIdWithBrandQueryResult>(value);
        }
    }
}
