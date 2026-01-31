using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.CQRS.Commands.ContactCommads
{
    public class RemoveContactCommand
    {
        public int Id { get; set; }
        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}
