using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.ServiceQueries;
using RentACarApp.Application.Features.Mediator.Results.ServiceResults;
using RentACarApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<RentACarApp.Domain.Entities.Services> _repository;
        private readonly IMapper _mapper;

        public GetServiceQueryHandler(IRepository<Domain.Entities.Services> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetServiceQueryResult>>(values);
        }
    }
}
