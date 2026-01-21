using kpo_hw1.Animals;
using kpo_hw1.Factories;
using kpo_hw1.ForZoo;
using kpo_hw1.Interfaces;
using kpo_hw1.UI;

namespace kpo_hw1;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    { 
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<AnimalFactory>();

        services.AddTransient<Monkey>();
        services.AddTransient<Rabbit>();
        services.AddTransient<Tiger>();
        services.AddTransient<Wolf>();

        services.AddSingleton<IZoo, Zoo>();
        services.AddSingleton<ZooPrinter>();
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        IZoo zoo = serviceProvider.GetRequiredService<IZoo>();
        ZooPrinter printer = serviceProvider.GetRequiredService<ZooPrinter>();
        AnimalFactory factory = serviceProvider.GetRequiredService<AnimalFactory>();
        
        ConsoleKeyInfo keyToExit = default;

        do
        {
            MethodsForConsole.Menu();
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int num))
            {
                Console.WriteLine("Некорректный ввод.");
                continue;
            }

            if (num == 1)
            {
                MethodsForConsole.AddAnimalFromConsole(zoo, factory);
            } 
            else if (num == 2)
            {
                MethodsForConsole.AddThingFromConsole(zoo);
            } 
            else if (num == 3)
            {
                if (printer != null) printer.PrintAllAnimals();
            } 
            else if (num == 4)
            {
                if (printer != null) printer.PrintAllThings();
            }
            else if (num == 5)
            {
                if (printer != null) printer.PrintKindAnimals();
            }
            else if (num == 6)
            {
                if (printer != null) printer.PrintCountOfAnimals();
            }
            else if (num == 7)
            {
                if (printer != null) printer.PrintEveryAnimalFoodCount();
            } 
            else if (num == 8)
            {
                if (printer != null) printer.PrintTotalFoodCount();
            } 
            else if (num == 9)
            {
                Console.WriteLine("Для выхода нажмите Escape....");
            }
            
            keyToExit = Console.ReadKey();
        } while (keyToExit.Key != ConsoleKey.Escape);
    }
}