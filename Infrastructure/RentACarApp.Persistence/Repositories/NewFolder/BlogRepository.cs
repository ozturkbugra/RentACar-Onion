using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.BlogInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.NewFolder
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentACarAppContext _context;

        public BlogRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthorsAsync()
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .OrderByDescending(b => b.BlogID)
                .Take(3)
                .ToListAsync();
        }
    }
}
