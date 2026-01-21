using kpo_hw1.Animals;
using kpo_hw1.Factories;
using kpo_hw1.Interfaces;
using kpo_hw1.Things;

namespace kpo_hw1.UI;

public static class MethodsForConsole
{
    public static void Menu()
    {
        Console.WriteLine("Выберите, что вы хотите сделать:");
        Console.WriteLine();
        Console.WriteLine("1. Добавить животное в зоопарк\n2. Добавить предмет в зоопарк\n3. Вывести всех животных зоопарка\n" +
                                 "4. Вывести весь инвентарь зоопарка\n5. Вывести животных, подходящих для контактного зоопарка\n" +
                                 "6. Вывести кол-во животных в каждой группе\n7. Вывести кол-во еды, потребляемое каждым животным\n" +
                                 "8. Вывести общее кол-во потребляемой еды\n9. Завершить программу");
    }
    
    public static int ReadIntFromConsole(string str)
    {
        while (true)
        {
            Console.Write(str);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("Ошибка: нужно ввести целое число. Попробуйте снова.");
        }
    }

    public static void AddAnimalFromConsole(IZoo zoo, AnimalFactory factory)
    {
        Console.WriteLine("Выберите тип животного:");
        Console.WriteLine("1. Обезьяна\n2. Кролик\n3. Тигр\n4. Волк");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Введите корректное значение.");
            return;
        }
        string type = input.Trim();
        
        try
        {
            Animal animal = factory.Create(type);

            animal.Number = ReadIntFromConsole("Введите номер животного: ");
            animal.Food = ReadIntFromConsole("Введите количество еды (кг): ");

            while (true)
            {
                Console.Write("Введите здоровье (healthy/sick): ");
                string? health = Console.ReadLine();
                try
                {
                    animal.Health = health;
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (animal is Herbo herbo)
            {
                int kindness = ReadIntFromConsole("Введите уровень доброты (0-10): ");
                if (kindness < 0 || kindness > 10) kindness = 5;
                herbo.LevelOfKindness = kindness;
            }

            zoo.AddAnimal(animal);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    public static void AddThingFromConsole(IZoo zoo)
    {
        Console.WriteLine("Выберите тип предмета:");
        Console.WriteLine("1. Стол\n2. Компьютер");

        Thing? thing;

        while (true)
        {
            string? choice = Console.ReadLine();
            thing = choice switch
            {
                "1" => new Table(),
                "2" => new Computer(),
                _ => null
            };

            if (thing != null) break;
            Console.WriteLine("Неверный выбор.");
        }

        thing.Number = ReadIntFromConsole("Введите номер предмета: ");

        while (true)
        {
            Console.Write("Введите название предмета: ");
            string? name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                thing.Name = name;
                break;
            }
            Console.WriteLine("Название не может быть пустым. Попробуйте снова.");
        }

        zoo.AddThing(thing);
    }
    
}