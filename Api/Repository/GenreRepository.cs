﻿using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _context;

        public GenreRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            await _context.Genre.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> DeleteAsync(Genre genre)
        {
            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> UpdateAsync(Genre genre)
        {
            _context.Genre.Update(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        public async Task<List<Genre>> GetAll()
        {
      
            var genres = await _context.Genre.ToListAsync();    
           
            return genres;
        }

        public async Task<Genre> GetById(int id)
        {
            var genres = await _context.Genre
                .Include(y => y.MovieSeriesGenres)
                .ThenInclude(e => e.MovieSeries)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (genres == null)
            {
                return null;
            }
                  
            return genres;
        }


        public async Task<List<MovieSeries>> GetMovieSeriesByGenre(int genreId)
        {
            return await _context.MovieSeriesGenre.Where(e => e.GenreId == genreId)
                .Select(e => e.MovieSeries).ToListAsync();
        }

        public async Task<bool> GenreExists(int id)
        {
            return await _context.Genre.AllAsync(e => e.Id == id);
        }
    }
}