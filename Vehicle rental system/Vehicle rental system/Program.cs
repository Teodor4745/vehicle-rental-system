using Vehicle_rental_system.Models.Customers;
using Vehicle_rental_system.Models.Rentals;
using Vehicle_rental_system.Models.Vehicles.Vehicle_rental_system.Vehicles;
using Vehicle_rental_system.Models.Vehicles;
using Vehicle_rental_system.Rental;
using Vehicle_rental_system.Services;

IBusinessRuleService businessRuleService = null;
IRentalService rentalService = null;

try
{
    businessRuleService = new BusinessRuleService();
    rentalService = new RentalService(businessRuleService);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while setting up services: {ex.Message}");
    return;
}

try
{
    IVehicle car = new Car
    {
        Brand = "Mitsubishi",
        Model = "Mirage",
        Value = 15000,
        RentalDays = 10,
        SafetyRating = 3
    };

    Customer carCustomer = new Customer("John Doe");

    DateTime carStartDate = DateTime.Parse("2024-06-03");
    DateTime carEndDate = DateTime.Parse("2024-06-13");
    DateTime carActualReturnDate = DateTime.Parse("2024-06-13");

    try
    {
        string carInvoice = rentalService.GenerateInvoice(carCustomer, car, carStartDate, carEndDate, carActualReturnDate);
        Console.WriteLine(carInvoice);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while generating car invoice: {ex.Message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while processing car rental: {ex.Message}");
}

try
{
    IVehicle motorcycle = new Motorcycle
    {
        Brand = "Yamaha",
        Model = "MT-07",
        Value = 7000,
        RentalDays = 5,
        RiderAge = 24
    };

    Customer motorcycleCustomer = new Customer("Jane Doe");

    DateTime motorcycleStartDate = DateTime.Parse("2024-07-01");
    DateTime motorcycleEndDate = DateTime.Parse("2024-07-06");
    DateTime motorcycleActualReturnDate = DateTime.Parse("2024-07-06");

    try
    {
        string motorcycleInvoice = rentalService.GenerateInvoice(motorcycleCustomer, motorcycle, motorcycleStartDate, motorcycleEndDate, motorcycleActualReturnDate);
        Console.WriteLine(motorcycleInvoice);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while generating motorcycle invoice: {ex.Message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while processing motorcycle rental: {ex.Message}");
}

try
{
    IVehicle cargoVan = new CargoVan
    {
        Brand = "Ford",
        Model = "Transit",
        Value = 30000,
        RentalDays = 12,
        DriverExperience = 6
    };

    Customer cargoVanCustomer = new Customer("Jim Beam");

    DateTime cargoVanStartDate = DateTime.Parse("2024-08-01");
    DateTime cargoVanEndDate = DateTime.Parse("2024-08-13");
    DateTime cargoVanActualReturnDate = DateTime.Parse("2024-08-13");

    try
    {
        string cargoVanInvoice = rentalService.GenerateInvoice(cargoVanCustomer, cargoVan, cargoVanStartDate, cargoVanEndDate, cargoVanActualReturnDate);
        Console.WriteLine(cargoVanInvoice);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while generating cargo van invoice: {ex.Message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while processing cargo van rental: {ex.Message}");
}