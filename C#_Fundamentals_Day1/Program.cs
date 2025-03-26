using System;

class Program
{
    enum CarType { Fuel, Electric }
    class Car
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
    }

    static List<Car> cars = new List<Car>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a car");
            Console.WriteLine("2. View all cars");
            Console.WriteLine("3. Search car by Make");
            Console.WriteLine("4. Filter car by Type");
            Console.WriteLine("5. Remove a car by Model");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");

            switch (Console.ReadLine())
            {
                case "1": AddCar(); break;
                case "2": ViewCars(); break;
                case "3": SearchCarByMake(); break;
                case "4": FilterCarByType(); break;
                case "5": RemoveCarByModel(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice! Try again."); break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private static void RemoveCarByModel()
    {
        Console.WriteLine("List of models:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}");
        }
        Console.Write("Enter Model to remove: ");
        string model = Console.ReadLine() ?? string.Empty;

        int removedCount = cars.RemoveAll(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

        if (removedCount == 0)
        {
            Console.WriteLine("No cars found with the specified model.");
        }
        else
        {
            Console.WriteLine($"{removedCount} car(s) removed successfully!");
        }
    }

    private static void FilterCarByType()
    {
        Console.WriteLine("Enter car type (Fuel/Electric): ");
        if (!Enum.TryParse(Console.ReadLine(), true, out CarType type))
        {
            Console.WriteLine("Invalid car type.");
            return;
        }
        var result = cars.Where(c => c.Type == type);
        if (!result.Any())
        {
            Console.WriteLine("No cars found.");
            return;
        }
        else
        {
            foreach (var car in result)
            {
                Console.WriteLine($"{car.Make} {car.Model} ({car.Year})");
            }
        }
    }

    private static void SearchCarByMake()
    {
        Console.Write("Enter Make to search: ");
        string make = Console.ReadLine() ?? string.Empty;
        var results = cars.Where(c => c.Make.Equals(make, StringComparison.OrdinalIgnoreCase));
        if (!results.Any()) Console.WriteLine("No cars found.");
        else foreach (var car in results) Console.WriteLine($"{car.Year} {car.Make} {car.Model} ({car.Type})");
    }

    private static void ViewCars()
    {
        if (!cars.Any())
        {
            Console.WriteLine("No cars found.");
            return;
        }
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Make} {car.Model} ({car.Year})");
        }
    }

    static void AddCar()
    {
        while (true)
        {
            Console.Write("Enter car type (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarType type))
            {
                Console.WriteLine("Invalid car type.");
                continue;
            }

            Console.Write("Enter Make: ");
            string make = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Model: ");
            string model = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year.");
                continue;
            }

            if (ExistedCar(make, model, year))
            {
                Console.WriteLine("Car already exists in the list.");
                Console.Write("Do you want to add another car? (Y/N): ");
                string response = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                if (response == "N")
                {
                    Console.WriteLine("Returning to the main menu.");
                    return;
                }
                else if (response == "Y")
                {
                    Console.WriteLine("Let's try adding another car.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Returning to the main menu.");
                    return;
                }
            }

            cars.Add(new Car { Make = make, Model = model, Year = year, Type = type });
            Console.WriteLine("Car added successfully!");
            return;
        }
    }
    static bool ExistedCar(string make, string model, int year)
    {
        return cars.Any(c => c.Make.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                             c.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
                             c.Year == year);
    }
}
