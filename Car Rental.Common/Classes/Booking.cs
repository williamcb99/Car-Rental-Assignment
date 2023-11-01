﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interface;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public string RegNo { get; set; }
    public Customer Customer { get; set; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public double Cost { get; set; }
    public BookingStatus BookingStatus { get; set; }

    public Booking(int id, string regNo, Customer customer, int kmRented, int kmReturned, DateTime dateRented, BookingStatus bookingStatus)
    {
        Id = id;
        RegNo = regNo;
        Customer = customer;
        KmRented = kmRented;
        KmReturned = kmReturned;
        DateRented = dateRented;
        DateReturned = new DateTime();
        BookingStatus = bookingStatus;
    }

    public void ReturnVehicle(IVehicle vehicle)
	{
        // Assign values to the class' properties with values from the vehicle parameter
        // Cost = days * vehicle.CostDay + km * vehicle.CostKm;
        var dayDifference = (DateReturned - DateRented).TotalDays;
        var kmDifference = KmReturned - vehicle.Odometer;
        Cost = (dayDifference * vehicle.DayPrice) + (kmDifference * vehicle.KmPrice);
    }
}
