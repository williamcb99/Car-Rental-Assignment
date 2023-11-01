using Car_Rental.Common.Classes;
using System.Runtime.CompilerServices;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateTime startDate, DateTime endDate)
    {
        return (int)(endDate - startDate).TotalDays;
    }
}
