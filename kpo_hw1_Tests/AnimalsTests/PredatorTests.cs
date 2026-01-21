using kpo_hw1.Animals;

namespace kpo_hw1_Tests;
using Xunit;
using kpo_hw1;

public class PredatorTests
{
    [Fact]
    public void PredatorAnimal_IsInstanceOfPredator()
    {
        Tiger tiger = new Tiger();
        Assert.IsAssignableFrom<Predator>(tiger);
    }

    [Fact]
    public void PredatorAnimal_IsInstanceOfAnimal()
    {
        Tiger tiger = new Tiger();
        Assert.IsAssignableFrom<Animal>(tiger); 
    }
    
    [Fact] 
    public void Tiger_IsExactlyTigerType()
    {
        Tiger tiger = new Tiger();
        Assert.IsType<Tiger>(tiger);    
    }

    [Fact]
    public void PredatorAnimal_LevelOfAgressionProperty_CanBeSet()
    {
        Tiger tiger = new Tiger { LevelOfAgression = 3 };
        Assert.Equal(3, tiger.LevelOfAgression);
    }
    
    [Fact]
    public void Wolf_IsInstanceOfPredator()
    {
        Wolf wolf = new Wolf();
        Assert.IsAssignableFrom<Predator>(wolf);
    }

    [Fact]
    public void Wolf_IsInstanceOfAnimal()
    {
        Wolf wolf = new Wolf();
        Assert.IsAssignableFrom<Animal>(wolf);
    }

    [Fact]
    public void Wolf_LevelOfAgressionProperty_CanBeSet()
    {
        Wolf wolf = new Wolf { LevelOfAgression = 5 };
        Assert.Equal(5, wolf.LevelOfAgression);
    }

    [Fact]
    public void Wolf_CanSetBasicProperties()
    {
        Wolf wolf = new Wolf { Number = 1001, Food = 8, Health = "healthy" };
        Assert.Equal(1001, wolf.Number);
        Assert.Equal(8, wolf.Food);
        Assert.Equal("healthy", wolf.Health);
    }

    [Fact]
    public void Wolf_ToString_ReturnsCorrectFormat()
    {
        Wolf wolf = new Wolf { Number = 1001 };
        string result = wolf.ToString();
        Assert.Equal("Животное: Волк, номер: 1001", result);
    }
}