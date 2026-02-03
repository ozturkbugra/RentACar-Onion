using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.TagCloudDtos
{
    public class ResultGetByBlogIdTagCloudDto
    {
        public int tagCloudID { get; set; }
        public string title { get; set; }
        public int blogID { get; set; }
    }
}
