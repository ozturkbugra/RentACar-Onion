using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.FeatureQueries;
using RentACarApp.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACarApp.Application.Features.Mediator.Results.FeatureResults;
using RentACarApp.Application.Features.Mediator.Results.FooterAddressResult;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IMapper mapper, IRepository<FooterAddress> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetFooterAddressQueryResult>>(values);
        }
    }
}
