using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.StatisticQueries;
using RentACarApp.Application.Features.Mediator.Results.StatisticResult;
using RentACarApp.Application.Interfaces.BrandInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class BrandCountQueryHandler : IRequestHandler<BrandCountQuery, BrandCountQueryResult>
    {
        private readonly IBrandRepository _repository;

        public BrandCountQueryHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BrandCountQueryResult> Handle(BrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.BrandCount();
            return new BrandCountQueryResult
            {
                BrandCount = value,
            };
        }
    }
}
