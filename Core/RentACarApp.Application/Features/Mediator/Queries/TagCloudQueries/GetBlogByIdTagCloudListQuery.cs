using MediatR;
using RentACarApp.Application.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetBlogByIdTagCloudListQuery : IRequest<List<GetBlogByIdTagCloudListQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogByIdTagCloudListQuery(int id)
        {
            Id = id;
        }
    }
}
