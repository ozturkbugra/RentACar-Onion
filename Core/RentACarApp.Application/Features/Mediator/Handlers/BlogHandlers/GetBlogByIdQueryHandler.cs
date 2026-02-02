using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.BlogQueries;
using RentACarApp.Application.Features.Mediator.Results.BlogResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null) {
                throw new Exception("Blog not found");
            }

            return _mapper.Map<GetBlogByIdQueryResult>(value);
        }
    }
}
