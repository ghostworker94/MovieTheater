using MovieTheater.DataBaseContext;
using MovieTheater.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieTheater.Service
{
    public class MovieApiService
    {
        private readonly DatabaseContext _dbContext;
        private readonly HttpClient client = new HttpClient();

        public MovieApiService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetMoviesFromApi()
        {
            var response = await client.GetAsync("https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=3fd2be6f0c70a2a598f084ddfb75487c");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Movie>(content);
                return result?.Results;
            }
            return null;
        }

        public async Task UpdateDatabaseWithMovies()
        {
            Random random = new Random();

            var movies = await GetMoviesFromApi();
            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    if (!_dbContext.Movie.Any(m => m.Id == movie.Id))
                    {
                        _dbContext.Add(new Movie
                        {
                            Adult = movie.Adult,
                            Backdrop_path = movie.Backdrop_path,
                            Genre_ids = movie.Genre_ids,
                            Id = movie.Id,
                            Original_language = movie.Original_language,
                            Original_title = movie.Original_title,
                            Overview = movie.Overview,
                            Popularity = movie.Popularity,
                            Poster_path = movie.Poster_path,
                            Release_date = movie.Release_date,
                            Title = movie.Title,
                            Video = movie.Video,
                            Vote_average = movie.Vote_average,
                            Vote_count = movie.Vote_count,
                            Value = random.Next(69, 420)
                        });
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}