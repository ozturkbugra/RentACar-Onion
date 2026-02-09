using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACarApp.Application.Features.Mediator.Results.CarFeatureResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.CarFeatureInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.CarFeatureByCarIdList(request.Id);
            return  _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(values);
        }
    }
}
