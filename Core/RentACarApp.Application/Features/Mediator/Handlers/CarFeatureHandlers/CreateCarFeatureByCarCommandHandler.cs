using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACarApp.Application.Interfaces.CarFeatureInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _repository;
        private readonly IMapper _mapper;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<CarFeature>(request);
            _repository.CreateCarFeatureByCar(values);
        }
    }
}
