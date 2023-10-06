using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;
using Car_Rental.Data.Interfaces;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
	private readonly IData _db;

	public BookingProcessor(IData db) => _db = db;

	public IEnumerable<Customer> GetCustomers() 
	{
		var customers = new List<Customer>();
		foreach (var customer in _db.GetPersons())
		{
			customers.Add((Customer)customer);
		}
		return customers;
	}

	public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) 
	{
		return _db.GetVehicles();
	}

	public IEnumerable<IBooking> GetBookings() 
	{
		var bookings = _db.GetBookings();

		var vehicles = _db.GetVehicles();
		

		foreach (var bk in bookings)
		{
			if(bk.BookingStatus == BookingStatus.Closed)
			{
				bk.ReturnVehicle(vehicles.First(r => r.RegNo == bk.RegNo));
			}
		}
		return bookings;
	}

}
