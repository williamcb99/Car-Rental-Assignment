using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(int id, string regNo, string make, int odometer, double kmPrice, VehicleTypes vehicleType, int dayPrice, VehicleStatuses vehicleStatus)
    {
        Id = id;
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        KmPrice = kmPrice;
        VehicleType = vehicleType;
        DayPrice = dayPrice;
        VehicleStatus = vehicleStatus;
    }
}
