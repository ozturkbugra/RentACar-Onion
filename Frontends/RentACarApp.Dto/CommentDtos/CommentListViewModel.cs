using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.CommentDtos
{
    public class CommentListViewModel
    {
        public List<ResultCommentDto> Comments { get; set; }
        public int CommentCount { get; set; }
    }
}
