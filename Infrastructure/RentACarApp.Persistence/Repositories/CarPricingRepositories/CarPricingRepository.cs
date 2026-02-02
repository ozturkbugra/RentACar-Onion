using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.CarPricingInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentACarAppContext _context;

        public CarPricingRepository(RentACarAppContext context)
        {
            _context = context;
        }
        public async Task<List<CarPricing>> GetCarsWithPricingsAsync()
        {
            return await _context.CarPricings
                .Include(cp => cp.Car)
                    .ThenInclude(c => c.Brand)
                .Include(cp => cp.Pricing)
                .Where(x=> x.PricingID == 3)
                .ToListAsync();
        }
    }
}
