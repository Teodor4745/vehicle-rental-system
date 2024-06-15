using Vehicle_rental_system.Models.Rentals;

namespace Vehicle_rental_system.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
        public int RentalDays { get; set; }
    }

}
