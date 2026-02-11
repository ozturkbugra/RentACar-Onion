using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.ReviewInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        public readonly RentACarAppContext _context;

        public ReviewRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewsByCarId(int id)
        {
            return await _context.Reviews.Where(x=> x.CarID == id).ToListAsync();
        }
    }
}
