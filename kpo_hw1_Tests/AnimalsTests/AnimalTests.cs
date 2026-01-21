using kpo_hw1;
using kpo_hw1.Animals;

namespace kpo_hw1_Tests.AnimalsTests;

public class AnimalTests
{
    [Fact]
    public void Animal_IdProperty_CanBeSetAndRetrieved()
    {
        Monkey monkey = new Monkey { Number = 1001 };

        Assert.Equal(1001, monkey.Number);
    }

    [Fact]
    public void Animal_FoodProperty_CanBeSetAndRetrieved()
    {
        Monkey monkey = new Monkey { Food = 5 };

        Assert.Equal(5, monkey.Food);
    }

    [Fact]
    public void Animal_HealthProperty_CanBeSetAndRetrieved()
    {
        Monkey monkey = new Monkey { Health = "healthy" };

        Assert.Equal("healthy", monkey.Health);
    }

    [Fact]
    public void Animal_ToString_ReturnsCorrectFormatWithNameAndId()
    {
        Monkey monkey = new Monkey { Number = 1001 };

        string result = monkey.ToString();

        Assert.Equal("Животное: Обезьяна, номер: 1001", result);
    }
    
    [Fact]
    public void Animal_HealthProperty_InvalidValue_ThrowsArgumentException()
    {
        Monkey monkey = new Monkey();
        Assert.Throws<ArgumentException>(() => monkey.Health = "invalid");
    }
}
