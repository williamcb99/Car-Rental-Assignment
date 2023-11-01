using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new();
    readonly List<IVehicle> _vehicles = new();
    readonly List<IBooking> _bookings = new();

    public CollectionData() => SeedData();

    public List<T> Get<T>(Expression<Func<T, bool>>? expression) where T : class
    {
        try
        {
            var getFields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.FieldType == typeof(List<T>)) ?? throw new InvalidOperationException();

            var value = getFields.GetValue(this) ?? throw new InvalidDataException();

            var newList = ((List<T>)value).AsQueryable();

            if (expression is null) return newList.ToList();

            return newList.Where(expression).ToList();

        }
        catch (Exception ex)
        {
            throw;
        }
        //FieldInfo[] fieldInfo = type.GetFields(BindingFlags.Public).Where(x => x.FieldType == type) ?? throw new ArgumentNullException();
    }

    public T? Single<T>(Expression<Func<T, bool>>? expression) where T : class
    {
        try
        {
            var getFields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.FieldType == typeof(List<T>)) ?? throw new InvalidOperationException();
            var value = getFields.GetValue(this) ?? throw new InvalidDataException();
            var newList = ((List<T>)value).AsQueryable();
            var item = newList.Single(expression);
            return item ?? throw new InvalidDataException();
        }
        catch (Exception)
        {
            throw;
        }
        
    }
    public void Add<T>(T item) where T : class
    {
        try
        {
            var getList = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(t => t.FieldType == typeof(List<T>)) ?? throw new InvalidOperationException();

            var value = getList.GetValue(this) ?? throw new InvalidDataException();

            ((List<T>)value).Add(item);

        }
        catch (Exception)
        {

            throw new ArgumentException("Unsupported type.");
        }
    }

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;

    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;

    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    void SeedData()
	{
		_persons.Add(new Customer(1, 12345, "John", "Doe"));
		_persons.Add(new Customer(2, 98765, "Jane", "Doe"));

		_vehicles.Add(new Car(1, "ABC123", "Volvo", 121329, 2, VehicleTypes.Suv, 300, VehicleStatuses.Available));
		_vehicles.Add(new Car(3, "DEF456", "Tesla", 21329, 3, VehicleTypes.Sedan, 500, VehicleStatuses.Available));
		_vehicles.Add(new Car(5, "GHI789", "Volkswagen", 181529, 1, VehicleTypes.Combi, 250, VehicleStatuses.Booked));

		_vehicles.Add(new Motorcycle(2, "JKL012", "Yamaha", 45132, 1, VehicleTypes.Motorcycle, 125, VehicleStatuses.Available));
		_vehicles.Add(new Motorcycle(4, "MNO345", "Honda", 5892, 2, VehicleTypes.Motorcycle, 175, VehicleStatuses.Available));
		_vehicles.Add(new Motorcycle(6, "PQR678", "Kawasaki", 412, 5, VehicleTypes.Motorcycle, 285, VehicleStatuses.Available));

		//_bookings.Add(new Booking(1, "PQR678", (Customer)_persons.Single(c => c.SSN == 98765), 412, 427, new DateTime(2023, 10, 01), BookingStatus.Closed));
        _bookings.Add(new Booking(2, "GHI789", (Customer)_persons.Single(c => c.SSN == 12345), 181529, 0, new DateTime(2023, 10, 01), BookingStatus.Open));

    }
}
