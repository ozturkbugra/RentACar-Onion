using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.CarFeatureInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;

namespace RentACarApp.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly RentACarAppContext _context;

        public CarFeatureRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> CarFeatureByCarIdList(int id)
        {
            return await _context.CarFeatures.Include(x => x.Feature).Where(X => X.CarID == id).ToListAsync();
        }
    }
}
