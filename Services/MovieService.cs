using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;
using MovieTheater.Models;

namespace MovieTheater.Services
{
    public class MovieService
    {
        private readonly DatabaseContext _context;
        public MovieService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movie.ToListAsync();
        }
        public async Task<Movie> GetMovie(int id)
        {
            return await _context.Movie.FindAsync(id);
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}