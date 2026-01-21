using kpo_hw1.Animals;
using kpo_hw1.ForZoo;
using kpo_hw1.Interfaces;
using kpo_hw1.Things;
using Microsoft.Extensions.DependencyInjection;

namespace kpo_hw1_Tests.TestsForZoo;

public class ZooTests
{
    private readonly IVeterinaryClinic _clinic;
    private readonly IZoo _zoo;

    public ZooTests()
    {
        _clinic = new VeterinaryClinic();
        _zoo = new Zoo(_clinic);
    }

    [Fact]
    public void AddAnimal_HealthyAnimal_IncreasesAnimalsCount()
    {
        Monkey monkey = new Monkey { Health = "healthy" };
        int countBefore = _zoo.Animals.Count;
        _zoo.AddAnimal(monkey);
        Assert.Equal(countBefore + 1, _zoo.Animals.Count);
    }

    [Fact]
    public void AddAnimal_HealthyAnimal_AddsCorrectAnimalToCollection()
    {
        Monkey monkey = new Monkey { Health = "healthy" };
        _zoo.AddAnimal(monkey);
        Assert.Contains(monkey, _zoo.Animals);
    }

    [Fact]
    public void AddAnimal_SickAnimal_DoesNotAddAnimal()
    {
        Tiger tiger = new Tiger { Health = "sick" };
        _zoo.AddAnimal(tiger);
        Assert.Empty(_zoo.Animals);
    }

    [Fact]
    public void AddAnimal_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _zoo.AddAnimal(null!));
    }

    [Fact]
    public void AddThing_ValidThing_IncreasesThingsCount()
    {
        Table table = new Table { Number = 1, Name = "Стол" };
        int countBefore = _zoo.Things.Count;
        _zoo.AddThing(table);
        Assert.Equal(countBefore + 1, _zoo.Things.Count);
    }

    [Fact]
    public void AddThing_ValidThing_AddsCorrectThingToCollection()
    {
        Table table = new Table { Number = 1, Name = "Стол" };
        _zoo.AddThing(table);
        Assert.Contains(table, _zoo.Things);
    }

    [Fact]
    public void AddThing_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _zoo.AddThing(null!));
    }

    [Fact]
    public void AnimalsProperty_IsReadOnly()
    {
        Assert.IsAssignableFrom<IReadOnlyList<Animal>>(_zoo.Animals);
    }

    [Fact]
    public void ThingsProperty_IsReadOnly()
    {
        Assert.IsAssignableFrom<IReadOnlyList<Thing>>(_zoo.Things);
    }

    [Fact]
    public void TotalFood_ForMultipleAnimals_CalculatesCorrectly()
    {
        Monkey monkey = new Monkey { Health = "healthy", Food = 5 };
        Rabbit rabbit = new Rabbit { Health = "healthy", Food = 2 };
        _zoo.AddAnimal(monkey);
        _zoo.AddAnimal(rabbit);

        int totalFood = 0;
        foreach (Animal animal in _zoo.Animals)
        {
            totalFood += animal.Food;
        }

        Assert.Equal(7, totalFood);
    }

    [Fact]
    public void KindAnimals_Filter_WorksCorrectly()
    {
        Monkey kindMonkey = new Monkey { Health = "healthy", LevelOfKindness = 7 };
        Rabbit notKindRabbit = new Rabbit { Health = "healthy", LevelOfKindness = 3 };
        _zoo.AddAnimal(kindMonkey);
        _zoo.AddAnimal(notKindRabbit);

        List<Animal> kindAnimals = new List<Animal>();
        foreach (Animal animal in _zoo.Animals)
        {
            if (animal is Herbo herbo && herbo.LevelOfKindness > 5)
            {
                kindAnimals.Add(animal);
            }
        }

        Assert.Single(kindAnimals);
        Assert.Contains(kindMonkey, kindAnimals);
        Assert.DoesNotContain(notKindRabbit, kindAnimals);
    }

    [Fact]
    public void VeterinaryClinic_CheckAnimal_HealthyAnimal_ReturnsTrue()
    {
        Monkey healthyAnimal = new Monkey { Health = "healthy" };

        bool result = _clinic.CheckAnimal(healthyAnimal);

        Assert.True(result);
    }

    [Fact]
    public void VeterinaryClinic_CheckAnimal_SickAnimal_ReturnsFalse()
    {
        Rabbit sickAnimal = new Rabbit { Health = "sick" };

        bool result = _clinic.CheckAnimal(sickAnimal);

        Assert.False(result);
    }

    [Fact]
    public void DIContainer_ShouldResolveZooAndClinic()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddSingleton<IZoo, Zoo>();
        ServiceProvider provider = services.BuildServiceProvider();

        IZoo resolvedZoo = provider.GetService<IZoo>()!;
        IVeterinaryClinic resolvedClinic = provider.GetService<IVeterinaryClinic>()!;

        Assert.NotNull(resolvedZoo);
        Assert.NotNull(resolvedClinic);
    }
}