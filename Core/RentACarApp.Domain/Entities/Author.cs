using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Domain.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public int Name { get; set; }
        public int ImageUrl { get; set; }
        public int Description { get; set; }

        public List<Blog> Blogs { get; set; }


    }
}
