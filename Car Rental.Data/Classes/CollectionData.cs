using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
	readonly List<IPerson> _persons = new List<IPerson>();
	readonly List<IVehicle> _vehicles = new List<IVehicle>();
	readonly List<IBooking> _bookings = new List<IBooking>();

	public CollectionData() => SeedData();

	void SeedData()
	{
		_persons.Add(new Customer(12345, "John", "Doe"));
		_persons.Add(new Customer(98765, "Jane", "Doe"));

		_vehicles.Add(new Car(1, "ABC123", "Volvo", 121329, 2, VehicleTypes.Suv, 300, VehicleStatuses.Available));
		_vehicles.Add(new Car(3, "DEF456", "Tesla", 21329, 3, VehicleTypes.Sedan, 500, VehicleStatuses.Available));
		_vehicles.Add(new Car(5, "GHI789", "Volkswagen", 181529, 1, VehicleTypes.Combi, 250, VehicleStatuses.Booked));

		_vehicles.Add(new Motorcycle(2, "JKL012", "Yamaha", 45132, 1, VehicleTypes.Motorcycle, 125, VehicleStatuses.Available));
		_vehicles.Add(new Motorcycle(4, "MNO345", "Honda", 5892, 2, VehicleTypes.Motorcycle, 175, VehicleStatuses.Available));
		_vehicles.Add(new Motorcycle(6, "PQR678", "Kawasaki", 412, 5, VehicleTypes.Motorcycle, 285, VehicleStatuses.Available));

		_bookings.Add(new Booking("PQR678", (Customer)_persons.Single(c => c.SSN == 98765), 412, 427, new DateTime(2023, 10, 01), new DateTime(2023, 10, 02), BookingStatus.Closed));
        _bookings.Add(new Booking("GHI789", (Customer)_persons.Single(c => c.SSN == 12345), 181529, 0, new DateTime(2023, 10, 01), new DateTime(2023, 10, 02), BookingStatus.Open));

    }

    public IEnumerable<IPerson> GetPersons() => _persons;

	public IEnumerable<IBooking> GetBookings() => _bookings;

	public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
}
