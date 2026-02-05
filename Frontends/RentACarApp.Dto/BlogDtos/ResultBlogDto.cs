using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.BlogDtos
{
    public class ResultBlogDto
    {
        public int blogID { get; set; }
        public string title { get; set; }
        public int authorID { get; set; }
        public string authorName { get; set; }
        public string categoryName { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryID { get; set; }
        public string description { get; set; }
    }
}
