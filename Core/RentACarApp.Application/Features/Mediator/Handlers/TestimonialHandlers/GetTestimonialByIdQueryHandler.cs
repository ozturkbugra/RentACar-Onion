using AutoMapper;
using MediatR;
using RentACarApp.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACarApp.Application.Features.Mediator.Results.TestimonialResults;
using RentACarApp.Application.Interfaces;
using RentACarApp.Domain.Entities;

namespace RentACarApp.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetTestimonialByIdQueryResult>(value);
        }
    }
}
