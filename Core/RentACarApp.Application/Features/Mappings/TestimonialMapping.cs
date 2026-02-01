using AutoMapper;
using RentACarApp.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACarApp.Application.Features.Mediator.Results.TestimonialResults;
using RentACarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mappings
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, GetTestimonialQueryResult>();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
            CreateMap<CreateTestimonialCommand, Testimonial>();
            CreateMap<UpdateTestimonialCommand, Testimonial>();
        }
    }
}
