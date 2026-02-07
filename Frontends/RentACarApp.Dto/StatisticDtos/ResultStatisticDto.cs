using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.StatisticDtos
{
    public class ResultStatisticDto
    {
        public string MaxCarByBrand { get; set; }

        public int CarCount { get; set; }

        public int BrandCount { get; set; }

        public decimal AvgCarPrice { get; set; }
    }
}
