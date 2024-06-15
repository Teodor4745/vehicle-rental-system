using System.Text;
using Vehicle_rental_system.Models.Customers;
using Vehicle_rental_system.Services;
using Vehicle_rental_system.Models.Rentals;

namespace Vehicle_rental_system.Rental
{
    public class RentalService : IRentalService
    {
        private readonly IBusinessRuleService _businessRuleService;

        public RentalService(IBusinessRuleService businessRuleService)
        {
            _businessRuleService = businessRuleService;
        }

        public decimal CalculateTotalCost(IVehicle vehicle)
        {
            decimal rentalCost = _businessRuleService.CalculateRentalCost(vehicle);
            decimal insuranceCost = _businessRuleService.CalculateInsuranceCost(vehicle);
            return rentalCost + insuranceCost;
        }

        public string GenerateInvoice(Customer customer, IVehicle vehicle, DateTime startDate, DateTime endDate, DateTime actualReturnDate)
        {
            vehicle.RentalDays = (actualReturnDate - startDate).Days;
            int reservedRentalDays = (endDate - startDate).Days;

            decimal rentalCostPerDay = _businessRuleService.CalculateRentalCost(vehicle) / vehicle.RentalDays;
            decimal insuranceCostPerDay = _businessRuleService.CalculateInsuranceCost(vehicle) / vehicle.RentalDays;

            var sb = new StringBuilder();
            sb.AppendLine("XXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.ToShortDateString()}");
            sb.AppendLine($"Customer Name: {customer.Name}");
            sb.AppendLine($"Rented Vehicle: {vehicle.Brand} {vehicle.Model}");
            sb.AppendLine($"Reservation start date: {startDate.ToShortDateString()}");
            sb.AppendLine($"Reservation end date: {endDate.ToShortDateString()}");
            sb.AppendLine($"Reserved rental days: {reservedRentalDays} days");
            sb.AppendLine();
            sb.AppendLine($"Actual Return date: {actualReturnDate.ToShortDateString()}");
            sb.AppendLine($"Actual rental days: {vehicle.RentalDays} days");
            sb.AppendLine();
            sb.AppendLine($"Rental cost per day: {rentalCostPerDay:C2}");
            sb.AppendLine($"Insurance per day: {insuranceCostPerDay:C2}");
            sb.AppendLine();
            sb.AppendLine($"Total rent: {_businessRuleService.CalculateRentalCost(vehicle):C2}");
            sb.AppendLine($"Total insurance: {_businessRuleService.CalculateInsuranceCost(vehicle):C2}");
            sb.AppendLine($"Total: {CalculateTotalCost(vehicle):C2}");
            sb.AppendLine("XXXXXXXX");

            return sb.ToString();
        }
    }



}
