using AutoMapper;
using RentACarApp.Application.Features.CQRS.Queries.BannerQueries;
using RentACarApp.Application.Features.CQRS.Results.BannerResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return _mapper.Map<GetBannerByIdQueryResult>(value);
        }
    }
}
