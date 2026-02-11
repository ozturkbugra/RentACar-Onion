using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.ReviewDtos
{
    public class ResultReviewByCarIdDto
    {
        public int reviewID { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string comment { get; set; }
        public int starCount { get; set; }
        public DateTime date { get; set; }

        public int carID { get; set; }
    }
}
