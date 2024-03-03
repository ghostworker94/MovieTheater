using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;
using MovieTheater.Models;

namespace MovieTheater.Service
{
    public class BookingService
    {
        private readonly DatabaseContext _context;
        public BookingService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<BookingTable>> GetBookings(int userId)
        {
            return await _context.BookingTable.Where(b => b.UserId == userId).ToListAsync();
        }
        public async Task<BookingTable> GetBooking(int id)
        {
            return await _context.BookingTable.FindAsync(id);
        }
        public async Task<BookingTable> AddBooking(BookingTable booking)
        {
            _context.BookingTable.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<BookingTable> UpdateBooking(BookingTable booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<BookingTable> DeleteBooking(int id)
        {
            var booking = await _context.BookingTable.FindAsync(id);
            if (booking == null)
            {
                return null;
            }
            _context.BookingTable.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}