using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.StatisticQueries;
using RentACarApp.Application.Features.Mediator.Results.StatisticResult;
using RentACarApp.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class AvgCarPricingDailyQueryHandler : IRequestHandler<AvgCarPricingDailyQuery, AvgCarPricingDailyQueryResult>
    {
        private readonly ICarPricingRepository _repository;

        public AvgCarPricingDailyQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<AvgCarPricingDailyQueryResult> Handle(AvgCarPricingDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.AvgCarPricingDaily();
            return new AvgCarPricingDailyQueryResult
            {
                AvgCarPrice = value,
            };
        }
    }
}
