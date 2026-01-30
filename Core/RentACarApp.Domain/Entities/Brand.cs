using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}
