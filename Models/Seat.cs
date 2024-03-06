using MovieTheater.Models;

public class Seat
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsSelected { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int? BookingTableId { get; set; }
    public BookingTable? BookingTable { get; set; }
}