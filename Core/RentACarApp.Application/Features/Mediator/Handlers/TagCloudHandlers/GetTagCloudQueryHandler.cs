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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetTagCloudQueryResult>>(values);
        }
    }
}
