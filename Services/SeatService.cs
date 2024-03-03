using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;

namespace MovieTheater.Services
{
    public class SeatService
    {
        private readonly DatabaseContext _context;
        public SeatService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Seat>> GetSeats(int movieId)
        {
            return await _context.Seat.Where(s => s.MovieId == movieId).ToListAsync();
        }
        public async Task<Seat> GetSeat(int id)
        {
            return await _context.Seat.FindAsync(id);
        }
        public async Task<Seat> AddSeat(Seat seat)
        {
            _context.Seat.Add(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task<Seat> UpdateSeat(Seat seat)
        {
            _context.Entry(seat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task<Seat> DeleteSeat(int id)
        {
            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return null;
            }
            _context.Seat.Remove(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
    }
}