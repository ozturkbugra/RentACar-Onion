using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Features.Mediator.Commands.CarFeatureCommands;
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

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.FirstOrDefault(x=> x.CarFeatureID == id);
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.FirstOrDefault(x => x.CarFeatureID == id);
            values.Available = true;
            _context.SaveChanges();
        }
    }
}
