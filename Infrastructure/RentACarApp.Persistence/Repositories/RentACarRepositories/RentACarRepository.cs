using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.RentACarInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly RentACarAppContext _context;

        public RentACarRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars
                .Where(filter)
                // 1. Önce Arabayı ve onun Markasını dahil edelim
                .Include(x => x.Car)
                    .ThenInclude(y => y.Brand)

                // 2. Şimdi Fiyatları Alalım (Tekrar Car üzerinden gidiyoruz)
                .Include(x => x.Car)
                    .ThenInclude(z => z.CarPricings) // Car -> CarPricings (Listeye girdik)
                        .ThenInclude(t => t.Pricing) // CarPricing -> Pricing (Fiyat adına ulaştık: Günlük, Aylık vs.)

                .ToListAsync();

            return values;

        }
    }
}
