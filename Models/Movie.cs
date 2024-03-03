namespace MovieTheater.Models
{
    public class Movie
    {
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public int[] Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public string Poster_path { get; set; }
        public DateOnly Release_date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
        public int Value { get; set; }
        public List<Movie> Results { get; set; }
        public Movie()
        {
            Random random = new Random();
            Value = random.Next(69, 230);
        }
    }
}