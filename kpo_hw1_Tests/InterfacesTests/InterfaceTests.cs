using kpo_hw1.Animals;
using kpo_hw1.Interfaces;
using kpo_hw1.Things;

namespace kpo_hw1_Tests.InterfacesTests;

public class InterfaceTests
{
    [Fact]
    public void Animal_ImplementsIAliveInterface()
    {
        Animal animal = new Monkey();
        Assert.IsAssignableFrom<IAlive>(animal);
    }

    [Fact]
    public void Animal_ImplementsIInventoryInterface()
    {
        Animal animal = new Monkey();
        Assert.IsAssignableFrom<IInventory>(animal);
    }

    [Fact]
    public void Thing_ImplementsIInventoryInterface()
    {
        Thing thing = new Table();
        Assert.IsAssignableFrom<IInventory>(thing);
    }

    [Fact]
    public void IAlive_FoodProperty_CanBeAccessed()
    {
        IAlive animal = new Monkey();
        Assert.True(animal.Food >= 0);
    }

    [Fact]
    public void IInventory_IdProperty_CanBeAccessed()
    {
        IInventory item = new Monkey();
        Assert.True(item.Number >= 0);
    }
}