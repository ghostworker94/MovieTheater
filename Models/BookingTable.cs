using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class BookingTable
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public DateTime PresentingDate { get; set; }
        public int MovieId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("MovieDetailsId")]
        public Movie Movie { get; set; }
        public List<Seat> Seat { get; set; }
        public int SeatId { get; set; }
    }
}