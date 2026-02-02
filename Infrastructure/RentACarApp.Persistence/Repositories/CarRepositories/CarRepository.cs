using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;

namespace RentACarApp.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentACarAppContext _context;

        public CarRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrandAsync()
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .ToListAsync();
        }

     
        public async Task<List<Car>> GetLast5CarsWithBrandAsync()
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .OrderByDescending(c => c.CarID)
                .Take(5)
                .ToListAsync();
        }
    }
}
