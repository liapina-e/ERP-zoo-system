using kpo_hw1.Animals;
using kpo_hw1.Interfaces;

namespace kpo_hw1.ForZoo;

public class ZooPrinter
{
    private readonly IZoo _zoo;

    public ZooPrinter(IZoo zoo)
    {
        if (zoo == null)
        {
            throw new ArgumentNullException(nameof(zoo));
        }
        
        _zoo = zoo;
    }
    
    private bool CheckEmpty<T>(IReadOnlyList<T> items, string emptyMessage)
    {
        if (items.Count == 0)
        {
            Console.WriteLine(emptyMessage);
            return true;
        }
        return false;
    }
    
    public void PrintAllAnimals()
    {
        if (CheckEmpty(_zoo.Animals, "В зоопарке нет животных. Сначала нужно их добавить."))
        {
            return;
        }
        
        Console.WriteLine("Животные, находящиеся в зоопарке:");
        Console.WriteLine();
        for (int i = 0; i < _zoo.Animals.Count; i++)
        {
            Console.WriteLine(_zoo.Animals[i].ToString());
        }
    }

    public void PrintAllThings()
    {
        if (CheckEmpty(_zoo.Things, "В зоопарке нет вещей. Сначала их нужно добавить."))
        {
            return;
        }
        
        Console.WriteLine("Предметы на балансе зоопарка:");
        Console.WriteLine();
        for (int i = 0; i < _zoo.Things.Count; i++)
        {
            Console.WriteLine(_zoo.Things[i].ToString());
        }
    }

    public void PrintKindAnimals()
    {
        if (CheckEmpty(_zoo.Animals, "В зоопарке нет животных. Сначала нужно их добавить."))
        {
            return;
        }
        
        for (int i = 0; i < _zoo.Animals.Count; i++)
        {
            if (_zoo.Animals[i] is Herbo herbo && herbo.CanContactWithPeople())
            {
                Console.WriteLine($"{_zoo.Animals[i].Name} с номером {_zoo.Animals[i].Number} может находиться в контактном зоопарке.");
            }
        }
    }

    public void PrintCountOfAnimals()
    {
        if (CheckEmpty(_zoo.Animals, "В зоопарке нет животных. Сначала нужно их добавить."))
        {
            return;
        }
        
        int countMonkey = _zoo.Animals.Count(x => x is Monkey);
        int countRabbit = _zoo.Animals.Count(x => x is Rabbit);
        int countTiger = _zoo.Animals.Count(x => x is Tiger);
        int countWolf = _zoo.Animals.Count(x => x is Wolf);
        
        Console.WriteLine($"Кол-во всех животных: {_zoo.Animals.Count}");
        Console.WriteLine($"Кол-во обезьян: {countMonkey}");
        Console.WriteLine($"Кол-во кроликов: {countRabbit}");
        Console.WriteLine($"Кол-во тигров: {countTiger}");
        Console.WriteLine($"Кол-во волков: {countWolf}");
    }

    public void PrintEveryAnimalFoodCount()
    {
        if (CheckEmpty(_zoo.Animals, "В зоопарке нет животных. Сначала нужно их добавить."))
        {
            return;
        }
        
        for (int i = 0; i < _zoo.Animals.Count; i++)
        {
            Console.WriteLine($"{_zoo.Animals[i].Name} с номером {_zoo.Animals[i].Number} потребляет {_zoo.Animals[i].Food} кг еды в день.");
        }
    }
    
    public void PrintTotalFoodCount()
    {
        int total = _zoo.Animals.Sum(animal => animal.Food);
        Console.WriteLine($"Общее потребление еды: {total} кг в день");
    }
}