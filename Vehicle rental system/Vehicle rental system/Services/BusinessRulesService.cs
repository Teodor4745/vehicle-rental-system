using Vehicle_rental_system.Models.Vehicles.Vehicle_rental_system.Vehicles;
using Vehicle_rental_system.Models.Vehicles;
using Vehicle_rental_system.Util;
using Vehicle_rental_system.Models.Rentals;

namespace Vehicle_rental_system.Services
{
    public class BusinessRuleService : IBusinessRuleService
    {
        public decimal CalculateRentalCost(IVehicle vehicle)
        {
            if (vehicle is Car)
            {
                return vehicle.RentalDays <= 7 ? Constants.CarDailyRentalCostShortTerm * vehicle.RentalDays : Constants.CarDailyRentalCostLongTerm * vehicle.RentalDays;
            }
            else if (vehicle is Motorcycle)
            {
                return vehicle.RentalDays <= 7 ? Constants.MotorcycleDailyRentalCostShortTerm * vehicle.RentalDays : Constants.MotorcycleDailyRentalCostLongTerm * vehicle.RentalDays;
            }
            else if (vehicle is CargoVan)
            {
                return vehicle.RentalDays <= 7 ? Constants.CargoVanDailyRentalCostShortTerm * vehicle.RentalDays : Constants.CargoVanDailyRentalCostLongTerm * vehicle.RentalDays;
            }
            throw new InvalidOperationException("Unknown vehicle type.");
        }

        public decimal CalculateInsuranceCost(IVehicle vehicle)
        {
            if (vehicle is Car car)
            {
                return Constants.CarInsuranceRate * car.Value * car.RentalDays * (car.SafetyRating >= 4 ? Constants.HighSafetyDiscount : 1.0m);
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                decimal cost = Constants.MotorcycleInsuranceRate * motorcycle.Value * motorcycle.RentalDays;
                if (motorcycle.RiderAge < 25) cost *= Constants.RiderAgeSurcharge;
                return cost;
            }
            else if (vehicle is CargoVan cargoVan)
            {
                decimal cost = Constants.CargoVanInsuranceRate * cargoVan.Value * cargoVan.RentalDays;
                if (cargoVan.DriverExperience > 5) cost *= Constants.DriverExperienceDiscount;
                return cost;
            }
            throw new InvalidOperationException("Unknown vehicle type.");
        }
    }
}
