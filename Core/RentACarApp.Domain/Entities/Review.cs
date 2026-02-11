using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int StarCount { get; set; }
        public DateTime Date { get; set; }

        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
