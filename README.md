
# Solution to the Vehicle Rental System Task

## Solution Explanation and Project Structure

- **Models**:
  - Represents the different rentals and their state.
  - `IVehicle`: Interface defining vehicle properties and methods.
  - `Vehicle`: Abstract base class implementing `IVehicle`.
  - `Car`, `Motorcycle`, `CargoVan`: Concrete vehicle classes inheriting from `Vehicle`.
  - `Customer`: Class representing a customer.

- **Services**:
  - Using Encapsulation and Dependency Injection the business rules are isolated in the BusinessRuleService and RentalService classes.
  - `IBusinessRuleService`: Interface defining business rule methods.
  - `BusinessRuleService`: Implements business rules for cost calculations.
  - `IRentalService`: Interface defining rental service methods.
  - `RentalService`: Implements rental operations including invoice generation.

- **Constants**: 
  - `Constants`: Class holding all scalar values used for the rentals.

