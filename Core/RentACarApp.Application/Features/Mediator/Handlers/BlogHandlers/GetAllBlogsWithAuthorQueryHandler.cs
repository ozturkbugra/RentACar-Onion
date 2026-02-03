using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.BlogQueries;
using RentACarApp.Application.Features.Mediator.Results.BlogResults;
using RentACarApp.Application.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IMapper mapper, IBlogRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllBlogsWithAuthor();
            return _mapper.Map<List<GetAllBlogsWithAuthorQueryResult>>(value);
        }
    }
}
