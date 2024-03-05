using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class BookingTable
    {
        public int Id { get; set; }
        public string[] Seatnumber { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public DateTime PresentingDate { get; set; }
        public int MovieId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("MovieDetailsId")]
        public virtual Movie Movie { get; set; }
        public List<Seat> Seat { get; set; }
        public int SeatId { get; set; }

        // public BookingTable()
        // {
        //     Random random = new Random();

        //     // Generera ett slumpmässigt månad mellan 1 och 12
        //     int month = random.Next(1, 13);

        //     // Generera ett slumpmässigt dag baserat på månaden
        //     int daysInMonth = DateTime.DaysInMonth(2024, month);
        //     int day = random.Next(1, daysInMonth + 1);

        //     int hour = random.Next(0, 24);
        //     int minute = random.Next(0, 60);
        //     int second = random.Next(0, 60);

        //     DateTime randomDateTime = new DateTime(2024, month, day, hour, minute, second);
        //     PresentingDate = randomDateTime;
        // }
    }
}