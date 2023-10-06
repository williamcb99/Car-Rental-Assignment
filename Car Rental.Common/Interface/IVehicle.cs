using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interface;

public interface IVehicle
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
