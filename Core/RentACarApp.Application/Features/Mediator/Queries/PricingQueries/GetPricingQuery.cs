using MediatR;
using RentACarApp.Application.Features.Mediator.Results.PricingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery: IRequest<List<GetPricingQueryResult>>
    {

    }
}
