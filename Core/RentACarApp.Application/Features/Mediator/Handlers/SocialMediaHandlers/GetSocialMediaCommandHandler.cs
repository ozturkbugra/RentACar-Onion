using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACarApp.Application.Features.Mediator.Results.SocialMediaResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaCommandHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public GetSocialMediaCommandHandler(IMapper mapper, IRepository<SocialMedia> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return _mapper.Map<List<GetSocialMediaQueryResult>>(value);
        }
    }
}
