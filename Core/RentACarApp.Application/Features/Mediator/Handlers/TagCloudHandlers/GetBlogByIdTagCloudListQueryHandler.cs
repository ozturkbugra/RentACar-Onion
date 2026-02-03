using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACarApp.Application.Features.Mediator.Results.TagCloudResults;
using RentACarApp.Application.Interfaces.TagCloudInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetBlogByIdTagCloudListQueryHandler : IRequestHandler<GetBlogByIdTagCloudListQuery, List<GetBlogByIdTagCloudListQueryResult>>
    {
        private readonly ITagCloudRepository _repository;
        private readonly IMapper _mapper;

        public GetBlogByIdTagCloudListQueryHandler(ITagCloudRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBlogByIdTagCloudListQueryResult>> Handle(GetBlogByIdTagCloudListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogByIdTagCloudList(request.Id);
            return _mapper.Map<List<GetBlogByIdTagCloudListQueryResult>>(values);
        }
    }
}
