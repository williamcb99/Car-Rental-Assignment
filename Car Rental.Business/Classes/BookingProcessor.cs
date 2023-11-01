using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;
using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Extensions;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    private readonly UserAddedInformation _uai;
    public bool IsTaskRunning { get; set; }

    public BookingProcessor(IData db, UserAddedInformation uai)
    {
        _db = db;
        _uai = uai;
    }
    public IEnumerable<IBooking> GetBookings()
    {
        return _db.Get<IBooking>(null);
    }
    //public IBooking GetBooking(int vehicleId) { }
    public IEnumerable<Customer> GetCustomers() 
	{
        return _db.Get<IPerson>(null).Cast<Customer>();
	}
    //public IPerson? GetPerson(string ssn) { }
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        return _db.Get<IVehicle>(null);
    }
    //public IVehicle? GetVehicle(int vehicleId) { }
    //public IVehicle? GetVehicle(string regNo) { }

    public async Task<IBooking> RentVehicle(int vehicleId, int customerId) 
    {
        IsTaskRunning = true;
        await Task.Delay(3000);
        int newId = _db.NextBookingId;
        var rentVehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        var rentCustomer = (Customer?)_db.Single<IPerson>(c => c.Id == customerId);
        var booking = new Booking(newId, rentVehicle.RegNo, rentCustomer, rentVehicle.Odometer, 0, DateTime.Now, BookingStatus.Open);
        rentVehicle.VehicleStatus = VehicleStatuses.Booked;
        _db.Add<IBooking>(booking);
        IsTaskRunning = false;

        return booking;

    }

    public IBooking ReturnVehicle(int vehicleId, int kmReturned) 
    {
        var vehicle = (Vehicle?)_db.Single<IVehicle>(v => v.Id == vehicleId) ?? throw new Exception();
        var booking = _db.Single<IBooking>(b => b.RegNo == vehicle.RegNo) ?? throw new Exception();
        if (vehicle.Odometer > kmReturned)
            throw new Exception($"Returned odometer ({kmReturned}) can not be greater than odometer at renting date. ");

        DateTime returnDate = DateTime.Now;
        int dateDifference = booking.DateRented.Duration(returnDate);
        double kmDifference = kmReturned - vehicle.Odometer;
        booking.Cost = (dateDifference * vehicle.DayPrice) + (kmDifference * vehicle.KmPrice);
        booking.BookingStatus = BookingStatus.Closed;
        booking.DateReturned = returnDate;
        booking.KmReturned = kmReturned;
        vehicle.Odometer = kmReturned;
        vehicle.VehicleStatus = VehicleStatuses.Available;

        return booking;
    }

    public void AddVehicle(string newRegNo, string newMake, int newOdometer, double newKmPrice, VehicleTypes newVehicleType, int newDayPrice)
    {
        int newId = _db.NextVehicleId;
        _uai.NewRegNo = newRegNo;
        _uai.NewMake = newMake;
        _uai.NewOdometer = newOdometer;
        _uai.NewKmPrice = newKmPrice;
        _uai.NewVehicleType = newVehicleType;
        VehicleStatuses newVehicleStatus = VehicleStatuses.Available;
        
        if (newVehicleType == VehicleTypes.Motorcycle)
        {
            var item = new Motorcycle(newId, newRegNo, newMake, newOdometer, newKmPrice, newVehicleType, newDayPrice, newVehicleStatus);
            _db.Add<IVehicle>(item);
        }
        else
        {
            var item = new Car(newId, newRegNo, newMake, newOdometer, newKmPrice, newVehicleType, newDayPrice, newVehicleStatus);
            _db.Add<IVehicle>(item);
        }
    }
    public void AddCustomer(int newSsn, string newFirstName, string newLastName)
    {
        int newId = _db.NextPersonId;
        _uai.NewSsn = newSsn;
        _uai.NewFirstName = newFirstName;
        _uai.NewLastName = newLastName;
        var item = new Customer(newId, newSsn, newFirstName, newLastName);
        _db.Add<IPerson>(item);

    }


}
