using Microsoft.EntityFrameworkCore;
using MovieTheater.Models;

namespace MovieTheater.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<BookingTable>()
            .HasOne(b => b.Movie)
            .WithMany()
            .HasForeignKey(b => b.MovieId);

            modelBuilder.Entity<Seat>()
            .HasOne(s => s.Movie)
            .WithMany()
            .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<BookingTable>()
            .HasOne(b => b.User)
            .WithMany(u => u.BookingTables)
            .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Seat>()
            .HasOne(s => s.BookingTable)
            .WithMany(b => b.Seat)
            .HasForeignKey(s => s.BookingTableId);
        }
    }
}