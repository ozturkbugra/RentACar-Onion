using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.CQRS.Results.AboutResults;
using RentACarApp.Application.Features.Mediator.Queries.FeatureQueries;
using RentACarApp.Application.Features.Mediator.Results.FeatureResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;

        public GetFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetFeatureQueryResult>>(values);
        }
    }
}
