using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;
using MovieTheater.Services;

namespace MovieTheater
{
    public class Seed
    {
        private readonly DatabaseContext _dataContext;
        private readonly MovieService _movieService;

        public Seed(DatabaseContext context, MovieService movieService)
        {
            _movieService = movieService;
            _dataContext = context;
        }
        public void SeedData()
        {
            var movies = _movieService.GetMovies();
            int rows = 6; // Antal rader
            int seatsPerRow = 9; // Antal säten per rad
            int totalSeats = rows * seatsPerRow; // Totalt antal säten

            if (_dataContext.Seat.Count() >= totalSeats)
            {
                Console.WriteLine("Maximalt antal poster har redan uppnåtts.");
                return;
            }

            foreach (var movie in _dataContext.Movie)
            {
                for (int row = 1; row <= rows; row++)
                {
                    for (int seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
                    {
                        seatNumber = seatNumber + 1;
                        if (_dataContext.Seat.Count() >= totalSeats)
                        {
                            Console.WriteLine("Maximalt antal poster har redan uppnåtts.");
                            return;
                        }

                        _dataContext.Seat.Add(new Seat
                        {
                            IsOccupied = false,
                            MovieId = movie.Id,
                            RowNumber = row,
                            SeatNumber = seatNumber
                        });
                    }
                }
            }
        }


    }
}