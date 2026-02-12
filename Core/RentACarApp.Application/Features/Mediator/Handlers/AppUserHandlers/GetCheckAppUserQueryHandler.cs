using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.AppUserQueries;
using RentACarApp.Application.Features.Mediator.Results.AppUserResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.AppUserInterfaces;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request,CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.UserName
                           && x.Password == request.Password);

            if (user == null)
                return new GetCheckAppUserQueryResult { IsExist = false };

            var result = _mapper.Map<GetCheckAppUserQueryResult>(user);
            return result;
        }

    }
}
