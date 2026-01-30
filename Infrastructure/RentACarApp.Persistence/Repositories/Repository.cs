using Microsoft.EntityFrameworkCore;
using RentACarApp.Application.Interfaces;
using RentACarApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RentACarAppContext _context;

        public Repository(RentACarAppContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
           _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
