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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<RentACarApp.Domain.Entities.Services> _repository;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IRepository<Domain.Entities.Services> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new Exception("Service bulunamadı");
            return _mapper.Map<GetServiceByIdQueryResult>(value);

        }
    }
}
