using kpo_hw1;
using kpo_hw1.Animals;

namespace kpo_hw1_Tests;

public class HerboTests
{
    [Fact]
    public void CanContactWithPeople_KindnessLevel6_ReturnsTrue()
    {
        Rabbit rabbit = new Rabbit { LevelOfKindness = 6 };
        bool result = rabbit.CanContactWithPeople();
        Assert.True(result);
    }

    [Fact]
    public void CanContactWithPeople_KindnessLevel5_ReturnsFalse()
    {
        Rabbit rabbit = new Rabbit { LevelOfKindness = 5 };
        bool result = rabbit.CanContactWithPeople();
        Assert.False(result);
    }

    [Fact]
    public void CanContactWithPeople_KindnessLevel4_ReturnsFalse()
    {
        Rabbit rabbit = new Rabbit { LevelOfKindness = 4 };
        bool result = rabbit.CanContactWithPeople();
        Assert.False(result);
    }

    [Fact]
    public void HerboAnimal_IsInstanceOfHerbo()
    {
        Monkey monkey = new Monkey();
        Assert.IsAssignableFrom<Herbo>(monkey);
    }

    [Fact]
    public void HerboAnimal_IsInstanceOfAnimal()
    {
        Monkey monkey = new Monkey();
        Assert.IsAssignableFrom<Animal>(monkey);
    }
    
    [Fact] 
    public void Monkey_IsExactlyMonkeyType()
    {
        Monkey monkey = new Monkey();
        Assert.IsType<Monkey>(monkey);    
    }
}