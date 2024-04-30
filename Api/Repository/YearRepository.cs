﻿using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class YearRepository : IYearRepository
    {
        private readonly MovieDbContext _context;

        public YearRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Year> CreateAsync(Year year)
        {
            await _context.Year.AddAsync(year);
            await _context.SaveChangesAsync();
            return year;
        }

        public async Task<Year> DeleteAsync(Year year)
        {
            _context.Year.Remove(year);
            await _context.SaveChangesAsync();
            return year;
        }
        public async Task<Year> UpdateAsync(Year year)
        {
            _context.Year.Update(year);
            await _context.SaveChangesAsync();
            return year;
        }
        public async Task<List<Year>> GetAll()
        {
            var year = await _context.Year.ToListAsync();
            return year;
        }

        public async Task<Year> GetById(int id)
        {
            return await _context.Year.FindAsync(id);
        }

        public Task<Year> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<Year>GetSeriesByYear(int yearId)
        {
            return await _context.Year.Include(e => e.Series).FirstOrDefaultAsync(e => e.Id == yearId);
        }
        public async Task<bool> YearExists(int id)
        {
            return await _context.Year.AnyAsync(e => e.Id == id);
        }
    }
}
