using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACarApp.Application.Features.Mediator.Results.TagCloudResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new Exception("Social Media not found");
            return _mapper.Map<GetTagCloudByIdQueryResult>(value);
        }
    }
}
