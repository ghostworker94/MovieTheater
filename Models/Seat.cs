using MovieTheater.Models;

public class Seat
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}