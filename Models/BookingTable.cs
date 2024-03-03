using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class BookingTable
    {
        public int Id { get; set; }
        public string[] Seatnumbers { get; set; }
        public int UserId { get; set; }
        public DateOnly PresentingDate { get; set; }
        public int MovieId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("MovieDetailsId")]
        public virtual Movie Movie { get; set; }
    }
}