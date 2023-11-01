using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;

namespace Car_Rental.Business.Classes;

public class UserAddedInformation
{
    int customerId;
    public string? NewFirstName { get; set; }
    public int CustomerId { get; set; }
    public int NewSsn { get; set; }
    public string? NewLastName { get; set; }
    public string? NewRegNo { get; set; }
    public string? NewMake { get; set; }
    public int NewOdometer { get; set; }
    public double NewKmPrice { get; set; }
    public VehicleTypes NewVehicleType { get; set; }
    public int NewDayPrice { get; set; }
    public int NewKmReturned { get; set; }
}
