using AutoMapper;
using RentACarApp.Application.Features.Mediator.Results.ReviewResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping() {

            CreateMap<Review, GetReviewByCarIdQueryResult>();
        }
    }
}
