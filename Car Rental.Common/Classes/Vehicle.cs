using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{	
	public int Id { get; set; }
	public string RegNo { get; set; }
	public string Make { get; set; }
	public int Odometer { get; set; }
	public double KmPrice { get; set; }
	public VehicleTypes VehicleType { get; set; }
	public int DayPrice { get; set; }
	public VehicleStatuses VehicleStatus { get; set; }

}
