using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.BlogQueries;
using RentACarApp.Application.Features.Mediator.Results.BlogResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.BlogInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetLast3BlogsWithAuthorsAsync();
           return _mapper.Map<List<GetLast3BlogsWithAuthorsQueryResult>>(values);
        }
    }
}
