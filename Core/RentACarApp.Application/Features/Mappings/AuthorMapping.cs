using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.AuthorCommands;
using RentACarApp.Application.Features.Mediator.Results.AuthorResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class AuthorMapping : Profile
    {
        public AuthorMapping()
        {
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<Author, GetAuthorQueryResult>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
        }
    }
}
