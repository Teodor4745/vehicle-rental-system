namespace Vehicle_rental_system.Models.Rentals
{
    public interface IVehicle
    {
        string Brand { get; set; }
        string Model { get; set; }
        decimal Value { get; set; }
        int RentalDays { get; set; }
    }
}
