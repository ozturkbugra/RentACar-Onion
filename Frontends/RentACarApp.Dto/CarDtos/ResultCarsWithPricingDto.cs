using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.CarDtos
{
    public class ResultCarsWithPricingDto
    {
        public int carID { get; set; }
        public int brandID { get; set; }
        public string brandName { get; set; }
        public string model { get; set; }
        public string coverImageUrl { get; set; }
        public int kM { get; set; }
        public string transmission { get; set; }
        public byte seat { get; set; }
        public byte luggage { get; set; }
        public string fuelType { get; set; }
        public string bigImageUrl { get; set; }
        public string pricingName { get; set; }
        public string pricingAmount { get; set; }
    }
}
