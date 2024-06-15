using Vehicle_rental_system.Models.Customers;
using Vehicle_rental_system.Models.Rentals;

namespace Vehicle_rental_system.Services
{
    public interface IRentalService
    {
        decimal CalculateTotalCost(IVehicle vehicle);
        string GenerateInvoice(Customer customer, IVehicle vehicle, DateTime startDate, DateTime endDate, DateTime actualReturnDate);
    }


}
