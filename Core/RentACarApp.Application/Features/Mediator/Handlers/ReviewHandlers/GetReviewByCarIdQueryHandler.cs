using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.ReviewQueries;
using RentACarApp.Application.Features.Mediator.Results.ReviewResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.ReviewInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public GetReviewByCarIdQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetReviewsByCarId(request.Id);
            return _mapper.Map<List<GetReviewByCarIdQueryResult>>(values);
        }
    }
}
