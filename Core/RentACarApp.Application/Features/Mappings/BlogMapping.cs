using AutoMapper;
using RentACarApp.Application.Features.CQRS.Results.CarResults;
using RentACarApp.Application.Features.Mediator.Commands.BlogCommands;
using RentACarApp.Application.Features.Mediator.Results.BlogResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<Blog, GetBlogQueryResult>();
            CreateMap<Blog, GetBlogByIdQueryResult>();
            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>();
            CreateMap<Blog, GetLast3BlogsWithAuthorsQueryResult>()
                        .ForMember(dest => dest.AuthorName,
                                   opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Blog, GetAllBlogsWithAuthorQueryResult>()
                .ForMember(dest => dest.AuthorName,
                    opt=> opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.CategoryName,
                    opt=> opt.MapFrom(src => src.Category.Name));
                
        }
    }
}
