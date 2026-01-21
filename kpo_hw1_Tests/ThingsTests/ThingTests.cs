using kpo_hw1.Things;

namespace kpo_hw1_Tests.ThingsTests;

public class ThingTests
{
    [Fact]
    public void Thing_IdProperty_CanBeSetAndRetrieved()
    {
        Table table = new Table { Number = 2001 };
        Assert.Equal(2001, table.Number);
    }

    [Fact]
    public void Thing_NameProperty_CanBeSetAndRetrieved()
    {
        Table table = new Table { Name = "Стол" };
        Assert.Equal("Стол", table.Name);
    }

    [Fact]
    public void Thing_ToString_ReturnsCorrectFormat()
    {
        Table table = new Table { Number = 2001, Name = "Стол" };
        string result = table.ToString();
        Assert.Equal("Предмет: Стол, номер: 2001", result);
    }
}