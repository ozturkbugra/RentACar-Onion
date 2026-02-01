using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.LocationCommands;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler: IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new Exception("Location bulunamadı.");

            await _repository.RemoveAsync(value);
        }

    }
}
