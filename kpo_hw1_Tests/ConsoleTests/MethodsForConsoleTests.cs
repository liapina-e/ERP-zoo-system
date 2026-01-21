using Microsoft.Extensions.DependencyInjection;
using kpo_hw1;
using kpo_hw1.Animals;
using kpo_hw1.Factories;
using kpo_hw1.ForZoo;
using kpo_hw1.Interfaces;
using kpo_hw1.Things;
using kpo_hw1.UI;

namespace kpo_hw1_Tests;

public class MethodsForConsoleTests : IDisposable
{
    private readonly ServiceProvider _provider;
    private readonly TextReader _originalIn;
    private readonly TextWriter _originalOut;

    public MethodsForConsoleTests()
    {
        _originalIn = Console.In;
        _originalOut = Console.Out;

        ServiceCollection services = new ServiceCollection();

        services.AddTransient<Monkey>();
        services.AddTransient<Rabbit>();
        services.AddTransient<Tiger>();
        services.AddTransient<Wolf>();

        services.AddSingleton<AnimalFactory>();
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddTransient<IZoo, Zoo>();

        _provider = services.BuildServiceProvider();
    }

    private IZoo NewZoo() => _provider.GetRequiredService<IZoo>();

    public void Dispose()
    {
        Console.SetIn(_originalIn);
        Console.SetOut(_originalOut);
    }

    [Fact]
    public void ReadIntFromConsole_ValidInput_ReturnsCorrectInteger()
    {
        Console.SetIn(new StringReader("42\n"));
        int result = MethodsForConsole.ReadIntFromConsole("Введите число: ");
        Assert.Equal(42, result);
    }

    [Fact]
    public void ReadIntFromConsole_InvalidThenValidInput_ReturnsCorrectInteger()
    {
        StringReader input = new StringReader("abc\n100\n");
        StringWriter output = new StringWriter();
        Console.SetIn(input);
        Console.SetOut(output);

        int result = MethodsForConsole.ReadIntFromConsole("Введите число: ");

        string consoleOutput = output.ToString();
        Assert.Contains("Ошибка: нужно ввести целое число", consoleOutput);
        Assert.Equal(100, result);
    }

    [Fact]
    public void AddAnimalFromConsole_ShouldAddHealthyAnimal()
    {
        IZoo zoo = NewZoo();
        AnimalFactory factory = _provider.GetRequiredService<AnimalFactory>();

        StringReader input = new StringReader(
            "1\n" +
            "123\n" +
            "5\n" +
            "healthy\n" +
            "7\n"
        );
        Console.SetIn(input);

        MethodsForConsole.AddAnimalFromConsole(zoo, factory);

        Animal animal = zoo.Animals[0];
        Assert.Single(zoo.Animals);
        Assert.Equal("Обезьяна", animal.Name);
        Assert.Equal(123, animal.Number);
        Assert.Equal(5, animal.Food);
        Assert.Equal("healthy", animal.Health);

        Herbo herbo = Assert.IsAssignableFrom<Herbo>(animal);
        Assert.Equal(7, herbo.LevelOfKindness);
    }

    [Fact]
    public void AddAnimalFromConsole_ShouldNotAddSickAnimal()
    {
        IZoo zoo = NewZoo();
        AnimalFactory factory = _provider.GetRequiredService<AnimalFactory>();

        StringReader input = new StringReader(
            "2\n" +
            "1\n" +
            "2\n" +
            "sick\n" +
            "7\n"
        );
        Console.SetIn(input);

        MethodsForConsole.AddAnimalFromConsole(zoo, factory);

        Assert.Empty(zoo.Animals);
    }

    [Fact]
    public void AddThingFromConsole_ShouldAddThing()
    {
        IZoo zoo = NewZoo();

        StringReader input = new StringReader(
            "1\n" +
            "3\n" +
            "Стол\n"
        );
        Console.SetIn(input);

        MethodsForConsole.AddThingFromConsole(zoo);

        Thing thing = zoo.Things[0];
        Assert.Single(zoo.Things);
        Assert.Equal("Стол", thing.Name);
        Assert.Equal(3, thing.Number);
    }
}

