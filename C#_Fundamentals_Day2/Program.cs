using System;

// Abstract class Car
abstract class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public DateTime LastMaintenanceDate { get; set; }

    public Car(string make, string model, int year, DateTime lastMaintenanceDate)
    {
        if (year < 1886 || year > DateTime.Now.Year)
            throw new ArgumentException("Invalid year. Please enter a valid year between 1886 and the current year.");
        if (lastMaintenanceDate > DateTime.Now)
            throw new ArgumentException("Last maintenance date cannot be in the future.");

        Make = make;
        Model = model;
        Year = year;
        LastMaintenanceDate = lastMaintenanceDate;
    }

    public DateTime ScheduleMaintenance()
    {
        return LastMaintenanceDate.AddMonths(6);
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Car: {Make} {Model} ({Year})");
        Console.WriteLine($"Last Maintenance: {LastMaintenanceDate:yyyy-MM-dd}");
        Console.WriteLine($"Next Maintenance: {ScheduleMaintenance():yyyy-MM-dd}");
    }
}

// Fuelable interface
interface IFuelable
{
    void Refuel(DateTime timeOfRefuel);
}

// Chargeable interface
interface IChargable
{
    void Charge(DateTime timeOfCharge);
}

// FuelCar class
class FuelCar : Car, IFuelable
{
    public FuelCar(string make, string model, int year, DateTime lastMaintenanceDate)
        : base(make, model, year, lastMaintenanceDate) { }

    public void Refuel(DateTime timeOfRefuel)
    {
        if (timeOfRefuel > DateTime.Now)
            throw new ArgumentException("Invalid date format! Please enter a valid date.");
        Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}");
    }
}

class ElectricCar : Car, IChargable
{
    public ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate)
        : base(make, model, year, lastMaintenanceDate) { }

    public void Charge(DateTime timeOfCharge)
    {
        if (timeOfCharge > DateTime.Now)
            throw new ArgumentException("Invalid date format! Please enter a valid date.");
        Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter car make: ");
            string make = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter car model: ");
            string model = Console.ReadLine() ?? string.Empty;

            int year;
            while (true)
            {
                Console.Write("Enter car year (e.g., 2020): ");
                if (int.TryParse(Console.ReadLine(), out year) && year >= 1886 && year <= DateTime.Now.Year)
                    break;
                Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
            }

            DateTime lastMaintenanceDate;
            while (true)
            {
                Console.Write("Enter last maintenance date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out lastMaintenanceDate) && lastMaintenanceDate <= DateTime.Now)
                    break;
                Console.WriteLine("Invalid date format! Please enter a valid date.");
            }

            Car car;
            while (true)
            {
                Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
                string type = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                if (type == "F")
                {
                    car = new FuelCar(make, model, year, lastMaintenanceDate);
                    break;
                }
                else if (type == "E")
                {
                    car = new ElectricCar(make, model, year, lastMaintenanceDate);
                    break;
                }
                Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
            }

            car.DisplayDetails();

            Console.Write("Do you want to refuel/charge? (Y/N): ");
            if ((Console.ReadLine() ?? string.Empty).Trim().ToUpper() == "Y")
            {
                DateTime actionTime;
                while (true)
                {
                    Console.Write("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ");
                    if (DateTime.TryParse(Console.ReadLine(), out actionTime) && actionTime <= DateTime.Now)
                        break;
                    Console.WriteLine("Invalid date format! Please enter a valid date.");
                }

                if (car is FuelCar fuelCar)
                    fuelCar.Refuel(actionTime);
                else if (car is ElectricCar electricCar)
                    electricCar.Charge(actionTime);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
