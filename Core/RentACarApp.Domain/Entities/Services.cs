using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Domain.Entities
{
    public class Services
    {
        public int ServicesID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
