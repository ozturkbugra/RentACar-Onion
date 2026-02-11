using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdWithBrandQuery
    {
        public int Id { get; set; }
        public GetCarByIdWithBrandQuery(int id)
        {
            Id = id;
        }
    }
}
