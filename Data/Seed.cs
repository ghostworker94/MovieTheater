using Microsoft.EntityFrameworkCore;
using MovieTheater.DataBaseContext;
using MovieTheater.Models;
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
        public void SeedSeatData()
        {
            var movies = _movieService.GetMovies();
            int rows = 6;
            int seatsPerRow = 9;
            int totalSeats = rows * seatsPerRow;

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
                        if (_dataContext.Seat.Count() >= totalSeats)
                        {
                            Console.WriteLine("Maximalt antal poster har redan uppnåtts.");
                            return;
                        }

                        _dataContext.Seat.AddRange(new Seat
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
        public void SeedGenreData()
        {
            Dictionary<int, string> genres = new Dictionary<int, string>
            {
                {1, "Musical"},
                {28, "Action"},
                {12, "Adventure"},
                {16, "Animation"},
                {35, "Comedy"},
                {80, "Crime"},
                {99, "Documentary"},
                {18, "Drama"},
                {10751, "Family"},
                {14, "Fantasy"},
                {36, "History"},
                {27, "Horror"},
                {10402, "Music"},
                {9648, "Mystery"},
                {10749, "Romance"},
                {878, "Science Fiction"},
                {10770, "TV Movie"},
                {53, "Thriller"},
                {10752, "War"},
                {37, "Western"},
                {10759, "Action & Adventure"},
                {10762, "Kids"},
                {10763, "News"},
                {10764, "Reality"},
                {10765, "Sci-Fi & Fantasy"},
                {10766, "Soap"},
                {10767, "Talk"},
                {10768, "War & Politics"}
            };

            foreach (var genre in genres)
            {
                _dataContext.Genre.Add(new Genre
                {
                    Id = genre.Key,
                    Name = genre.Value
                });
            }
            _dataContext.SaveChanges();
        }

    }
}