using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces.AppUserInterfaces;
using RentACarApp.Domain.Entities;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly RentACarAppContext _context;

        public AppUserRepository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _context.AppUsers.Include(x=> x.AppRole).FirstOrDefaultAsync(filter);
        }
    }
}
