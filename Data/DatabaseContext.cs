using Microsoft.EntityFrameworkCore;
using MovieTheater.Models;

namespace MovieTheater.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
    }
}