using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int StarCount { get; set; }
        public DateTime Date { get; set; }
        public int CarID { get; set; }
    }
}
