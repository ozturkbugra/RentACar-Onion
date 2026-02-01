using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.LocationQueries;
using RentACarApp.Application.Features.Mediator.Results.LocationResult;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.LocationHandlers
{
    internal class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value =  await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetLocationByIdQueryResult>(value);
        }
    }
}
