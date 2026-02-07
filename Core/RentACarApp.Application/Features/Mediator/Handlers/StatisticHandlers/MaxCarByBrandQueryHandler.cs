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
    public class MaxCarByBrandQueryHandler : IRequestHandler<MaxCarByBrandQuery, MaxCarByBrandQueryResult>
    {
        private readonly IBrandRepository _repository;

        public MaxCarByBrandQueryHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<MaxCarByBrandQueryResult> Handle(MaxCarByBrandQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.MaxCarByBrand();
            return new MaxCarByBrandQueryResult
            {
                MaxCarByBrand = value,
            };
        }
    }
}
