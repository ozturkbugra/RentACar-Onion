using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.RentACarQueries;
using RentACarApp.Application.Features.Mediator.Results.RentACarResults;
using RentACarApp.Application.Interfaces.RentACarInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x=> x.LocationID == request.LocationID && x.Available == true);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarID = x.CarID,
            }).ToList();
        }
    }
}
