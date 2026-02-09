using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeTrueCommand: IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChangeTrueCommand(int id)
        {
            Id = id;
        }
    }
}
