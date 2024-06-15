using Vehicle_rental_system.Models.Rentals;

namespace Vehicle_rental_system.Services
{
    public interface IBusinessRuleService
    {
        decimal CalculateRentalCost(IVehicle vehicle);
        decimal CalculateInsuranceCost(IVehicle vehicle);
    }
}
