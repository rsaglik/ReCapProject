using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string CarList = "Cars list";
        public static string CarNameValid = "Car name is invalid";
        public static string CarDailyPriceValid = "The daily price of the car must be greater than 0!";

        public static string MaintenanceTime = "System maintenance is being done";

        public static string RentalNotComeBack = "Since the vehicle has not been delivered yet, it cannot be rented";
        public static string Rented = "The car is rented";
    }
}
