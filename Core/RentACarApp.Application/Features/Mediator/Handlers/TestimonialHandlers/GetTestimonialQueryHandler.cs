using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACarApp.Application.Features.Mediator.Results.TestimonialResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;

namespace RentACarApp.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetTestimonialQueryResult>>(values);
        }
    }
}
