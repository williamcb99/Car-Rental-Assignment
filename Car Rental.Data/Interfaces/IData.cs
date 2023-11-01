using Car_Rental.Common.Interface;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    List<T> Get<T>(Expression<Func<T, bool>>? expression) where T : class;
    T? Single<T>(Expression<Func<T, bool>>? expression) where T : class;
    public void Add<T>(T item) where T : class;
    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    // Default Interface Methods
    //public string[] VehicleStatusNames => (VehicleStatuses); //Retunera enum konstanterna
    //public string[] VehicleTypeNames =>  VehicleTypes; //Retunera enum konstanterna
    //public VehicleTypes GetVehicleType(string name) => //Retunera en enum konstants värde med hjälp av konstantens namn
}
