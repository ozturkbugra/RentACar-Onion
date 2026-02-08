using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Features.Mediator.Results.CarPricingResults;
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

        public decimal AvgCarPricingDaily()
        {
            return _context.CarPricings.Where(x=> x.PricingID == 3).Average(x => x.Amount);
        }

        public List<GetCarPricingWithTimePeriodQueryResult> GetCarPricingWithTimePeriod()
        {
            var values = from x in _context.CarPricings
                         group x by x.CarID into g // Arabaya göre grupla
                         select new GetCarPricingWithTimePeriodQueryResult
                         {
                             // Model Adı: Marka + Model (Örn: Mercedes CLA 200)
                             Model = g.Select(y => y.Car.Model).FirstOrDefault(),
                             DailyAmount = g.Where(y => y.PricingID == 3).Sum(z => z.Amount),
                             WeeklyAmount = g.Where(y => y.PricingID == 4).Sum(z => z.Amount),
                             MonthlyAmount = g.Where(y => y.PricingID == 5).Sum(z => z.Amount),
                             BrandName = g.Select(y => y.Car.Brand.Name).FirstOrDefault(),
                             CoverImageUrl = g.Select(y => y.Car.CoverImageUrl).FirstOrDefault(),
                             CarID = g.Select(y=> y.CarID).FirstOrDefault(),
                         };

            return values.ToList();
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
