using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.ServiceDtos
{
    public class CreateServiceDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
    }
}
