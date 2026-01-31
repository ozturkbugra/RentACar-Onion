using AutoMapper;
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
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetBannerQueryResult>>(values);
        }
    }
}
