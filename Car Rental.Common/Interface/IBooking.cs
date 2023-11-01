using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interface;

public interface IBooking
{
    public int Id { get; set; }
    public string RegNo { get; set; }
    public Customer Customer {  get; set; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public double Cost { get; set; }
    public BookingStatus BookingStatus { get; set; }

}
