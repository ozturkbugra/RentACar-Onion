using RentACarApp.Application.Interfaces.BrandInterfaces;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.BrandRepositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly RentACarAppContext _context;

        public BrandRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public string MaxCarByBrand()
        {
            return _context.Brands
            .OrderByDescending(b => b.Cars.Count)
            .Select(b => b.Name)
            .FirstOrDefault();
        }
    }
}
