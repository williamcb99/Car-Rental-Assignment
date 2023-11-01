using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
	public Motorcycle(int id, string regNo, string make, int odometer, double kmPrice, VehicleTypes vehicleType, int dayPrice, VehicleStatuses vehicleStatus)
	{
		Id = id;
		RegNo = regNo;
		Make = make;
		Odometer = odometer;
		KmPrice = kmPrice;
		VehicleType = VehicleTypes.Motorcycle;
		DayPrice = dayPrice;
		VehicleStatus = vehicleStatus;
	}
}
