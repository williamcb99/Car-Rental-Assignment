﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
	IEnumerable<IPerson> GetPersons();
	IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
	IEnumerable<IBooking> GetBookings();
}
