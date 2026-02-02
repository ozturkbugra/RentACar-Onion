using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Results.AuthorResults
{
    public class GetAuthorByIdQueryResult
    {
        public int AuthorID { get; set; }
        public int Name { get; set; }
        public int ImageUrl { get; set; }
        public int Description { get; set; }
    }
}
