using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.TagCloudInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentACarAppContext _context;

        public TagCloudRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetBlogByIdTagCloudList(int blogid)
        {
            return await _context.TagClouds
                .Where(x => x.BlogID == blogid)
                .AsNoTracking().ToListAsync();
        }
    }
}
