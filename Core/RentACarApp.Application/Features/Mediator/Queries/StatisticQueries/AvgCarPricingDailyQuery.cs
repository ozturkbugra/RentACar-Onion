using MediatR;
using RentACarApp.Application.Features.Mediator.Results.StatisticResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Queries.StatisticQueries
{
    public class AvgCarPricingDailyQuery : IRequest<AvgCarPricingDailyQueryResult>
    {
    }
}
