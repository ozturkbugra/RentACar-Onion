using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Domain.Entities
{
    public class RentACar
    {
        public int RentACarID { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }

        public int CarID { get; set; }

        public Car Car { get; set; }

        // Araba müsait mi
        public bool Available { get; set; }

    }
}
