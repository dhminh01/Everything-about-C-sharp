// Add edit vehicles, there are the exact same vehicles!!!
// Add "back button" to main menu


// using System;

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
            DisplayMenu();

            switch (Console.ReadLine())
            {
                case "1": AddCar(); break;
                case "2": ViewCars(); break;
                case "3": SearchCarByMake(); break;
                case "4": FilterCarByType(); break;
                case "5": RemoveCarByModel(); break;
                case "6": EditCar(); break;
                case "7": return;
                default: Console.WriteLine("Invalid choice! Try again."); break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add a car");
        Console.WriteLine("2. View all cars");
        Console.WriteLine("3. Search car by Make");
        Console.WriteLine("4. Filter car by Type");
        Console.WriteLine("5. Remove a car by Model");
        Console.WriteLine("6. Edit a car");
        Console.WriteLine("7. Exit");
        Console.WriteLine("Enter your choice:");
    }

    private static void RemoveCarByModel()
    {
        if (BackToMainMenu("Press Enter to continue to remove car by Model, or 'B' to go back: ")) return;
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
        if (BackToMainMenu("Press Enter to continue to filter car by Type, or 'B' to go back: ")) return;
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
                Console.WriteLine($"{car.Make} {car.Model} ({car.Year}) - {car.Type}");
            }
        }
    }

    private static void SearchCarByMake()
    {
        if (BackToMainMenu("Press Enter to continue to search car by Make, or 'B' to go back: ")) return;
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
            int index = 1;

            Console.WriteLine($"{index}. {car.Make} {car.Model} ({car.Year})");
        }
    }

    static void AddCar()
    {
        while (true)
        {
            if (BackToMainMenu("Press Enter to continue to add car type, or 'B' to go back: ")) return;
            Console.Write("Enter car type (Fuel/Electric): ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarType type))
            {
                Console.WriteLine("Invalid car type.");
                continue;
            }
            if (BackToMainMenu("Press Enter to continue to add make, or 'B' to go back: ")) return;
            Console.Write("Enter Make: ");
            string make = Console.ReadLine() ?? string.Empty;
            if (BackToMainMenu("Press Enter to continue to add car model, or 'B' to go back: ")) return;
            Console.Write("Enter Model: ");
            string model = Console.ReadLine() ?? string.Empty;
            if (BackToMainMenu("Press Enter to continue to add car year of production, or 'B' to go back: ")) return;
            int year;
            while (true)
            {
                Console.Write("Enter Year: ");
                if (int.TryParse(Console.ReadLine(), out year) && year >= 1900 && year <= DateTime.Now.Year)
                {
                    break;
                }
                Console.WriteLine("Invalid year. Please try again:");
            }

            // if (ExistedCar(make, model, year))
            // {
            //     Console.WriteLine("Car already exists in the list.");
            //     Console.Write("Do you want to add another car? (Y/N): ");
            //     string response = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
            //     if (response == "N")
            //     {
            //         Console.WriteLine("Returning to the main menu.");
            //         return;
            //     }
            //     else if (response == "Y")
            //     {
            //         Console.WriteLine("Let's try adding another car.");
            //         continue;
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid input. Returning to the main menu.");
            //         return;
            //     }
            // }

            cars.Add(new Car { Make = make, Model = model, Year = year, Type = type });
            Console.WriteLine("Car added successfully!");
            return;
        }
    }
    // static bool ExistedCar(string make, string model, int year)
    // {
    //     return cars.Any(c => c.Make.Equals(make, StringComparison.OrdinalIgnoreCase) &&
    //                          c.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
    //                          c.Year == year);
    // }
    private static void EditCar()
    {
        if (!cars.Any())
        {
            Console.WriteLine("No cars in the list!");
            return;
        }

        ViewCars();

        if (BackToMainMenu("Press Enter to continue, or 'B' to go back: ")) return;
        Console.Write("Enter the number of the car to edit: ");

        string input = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!int.TryParse(input, out int index) || index < 1 || index > cars.Count)
        {
            Console.WriteLine("Invalid selection. Try again.");
            return;
        }

        Car carToEdit = cars[index - 1];
        Console.WriteLine($"Editing {carToEdit.Make} {carToEdit.Model} ({carToEdit.Year}) - {carToEdit.Type}");

        Console.Write("Enter new Make (or press Enter to keep current): ");
        string newMake = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!string.IsNullOrEmpty(newMake)) carToEdit.Make = newMake;

        Console.Write("Enter new Model (or press Enter to keep current): ");
        string newModel = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!string.IsNullOrEmpty(newModel)) carToEdit.Model = newModel;

        while (true)
        {
            Console.Write($"Enter new Year (or press Enter to keep {carToEdit.Year}): ");
            string newYearInput = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(newYearInput)) break;
            if (int.TryParse(newYearInput, out int newYear) && newYear >= 1900 && newYear <= DateTime.Now.Year)
            {
                carToEdit.Year = newYear;
                break;
            }
            Console.WriteLine("Invalid year. Try again.");
        }

        Console.Write("Enter new Type (Fuel/Electric) or press Enter to keep current: ");
        string newTypeInput = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!string.IsNullOrEmpty(newTypeInput) && Enum.TryParse(newTypeInput, true, out CarType newType))
        {
            carToEdit.Type = newType;
        }

        Console.WriteLine("Car updated successfully!");
    }

    private static bool BackToMainMenu(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        if (input.Equals("B", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Returning to the main menu...");
            return true;
        }

        return false;
    }


}
