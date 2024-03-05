using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;
using MovieTheater.Models;

namespace MovieTheater.Services
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
        public DateTime RandomDate()
        {
            Random random = new Random();

            // Generera ett slumpmässigt månad mellan 1 och 12
            int month = random.Next(1, 13);

            // Generera ett slumpmässigt dag baserat på månaden
            int daysInMonth = DateTime.DaysInMonth(2024, month);
            int day = random.Next(1, daysInMonth + 1);

            int hour = random.Next(0, 24);
            int minute = random.Next(0, 60);
            int second = random.Next(0, 60);

            DateTime randomDateTime = new DateTime(2024, month, day, hour, minute, second);
            return randomDateTime;
        }
    }
}