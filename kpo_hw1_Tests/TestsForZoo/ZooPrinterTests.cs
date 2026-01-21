using kpo_hw1.Animals;
using kpo_hw1.ForZoo;
using kpo_hw1.Things;

namespace kpo_hw1_Tests.TestsForZoo;

public class ZooPrinterTests
{
    private readonly Zoo _zoo;
    private readonly ZooPrinter _printer;

    public ZooPrinterTests()
    {
        var clinic = new VeterinaryClinic();
        _zoo = new Zoo(clinic);
        _printer = new ZooPrinter(_zoo);
    }

    [Fact]
    public void Constructor_NullZoo_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new ZooPrinter(null!));
    }

    [Fact]
    public void PrintAllAnimals_NoAnimals_PrintsEmptyMessage()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintAllAnimals();

        Assert.Contains("В зоопарке нет животных. Сначала нужно их добавить.", writer.ToString());
    }

    [Fact]
    public void PrintAllAnimals_WithAnimals_PrintsAnimalInfo()
    {
        var monkey = new Monkey { Health = "healthy", Number = 1 };
        _zoo.AddAnimal(monkey);

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintAllAnimals();

        Assert.Contains("Животные, находящиеся в зоопарке:", writer.ToString());
        Assert.Contains(monkey.Name, writer.ToString());
    }

    [Fact]
    public void PrintAllThings_NoThings_PrintsEmptyMessage()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintAllThings();

        Assert.Contains("В зоопарке нет вещей. Сначала их нужно добавить.", writer.ToString());
    }

    [Fact]
    public void PrintAllThings_WithThings_PrintsThingInfo()
    {
        var table = new Table { Number = 1, Name = "Стол" };
        _zoo.AddThing(table);

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintAllThings();

        Assert.Contains("Предметы на балансе зоопарка:", writer.ToString());
        Assert.Contains(table.Name, writer.ToString());
    }

    [Fact]
    public void PrintKindAnimals_NoAnimals_PrintsEmptyMessage()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintKindAnimals();

        Assert.Contains("В зоопарке нет животных. Сначала нужно их добавить.", writer.ToString());
    }

    [Fact]
    public void PrintKindAnimals_WithKindAnimal_PrintsAnimalInfo()
    {
        var rabbit = new Rabbit { Health = "healthy", Number = 1, LevelOfKindness = 7 };
        _zoo.AddAnimal(rabbit);

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintKindAnimals();

        Assert.Contains(rabbit.Name, writer.ToString());
        Assert.Contains("может находиться в контактном зоопарке", writer.ToString());
    }

    [Fact]
    public void PrintCountOfAnimals_NoAnimals_PrintsEmptyMessage()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintCountOfAnimals();

        Assert.Contains("В зоопарке нет животных. Сначала нужно их добавить.", writer.ToString());
    }

    [Fact]
    public void PrintCountOfAnimals_WithAnimals_PrintsCorrectCounts()
    {
        _zoo.AddAnimal(new Monkey { Health = "healthy" });
        _zoo.AddAnimal(new Rabbit { Health = "healthy" });
        _zoo.AddAnimal(new Tiger { Health = "healthy" });
        _zoo.AddAnimal(new Wolf { Health = "healthy" });

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintCountOfAnimals();

        string output = writer.ToString();
        Assert.Contains("Кол-во всех животных: 4", output);
        Assert.Contains("Кол-во обезьян: 1", output);
        Assert.Contains("Кол-во кроликов: 1", output);
        Assert.Contains("Кол-во тигров: 1", output);
        Assert.Contains("Кол-во волков: 1", output);
    }

    [Fact]
    public void PrintEveryAnimalFoodCount_NoAnimals_PrintsEmptyMessage()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintEveryAnimalFoodCount();

        Assert.Contains("В зоопарке нет животных. Сначала нужно их добавить.", writer.ToString());
    }

    [Fact]
    public void PrintEveryAnimalFoodCount_WithAnimals_PrintsFoodInfo()
    {
        var monkey = new Monkey { Health = "healthy", Number = 1, Food = 5 };
        var rabbit = new Rabbit { Health = "healthy", Number = 2, Food = 2 };
        _zoo.AddAnimal(monkey);
        _zoo.AddAnimal(rabbit);

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintEveryAnimalFoodCount();

        string output = writer.ToString();
        Assert.Contains(monkey.Name, output);
        Assert.Contains("5 кг", output);
        Assert.Contains(rabbit.Name, output);
        Assert.Contains("2 кг", output);
    }

    [Fact]
    public void PrintTotalFoodCount_WithAnimals_PrintsTotalFood()
    {
        _zoo.AddAnimal(new Monkey { Health = "healthy", Food = 5 });
        _zoo.AddAnimal(new Rabbit { Health = "healthy", Food = 2 });

        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintTotalFoodCount();

        string output = writer.ToString();
        Assert.Contains("Общее потребление еды: 7 кг", output);
    }

    [Fact]
    public void PrintTotalFoodCount_NoAnimals_PrintsZero()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);

        _printer.PrintTotalFoodCount();

        Assert.Contains("Общее потребление еды: 0 кг", writer.ToString());
    }
}