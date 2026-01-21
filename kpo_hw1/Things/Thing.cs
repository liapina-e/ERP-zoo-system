using kpo_hw1.Interfaces;

namespace kpo_hw1.Things;

public abstract class Thing : IInventory
{
    public int Number { get; set; }
    
    private string? _name;
    public string Name
    {
        get => _name ?? throw new InvalidOperationException("Name not set");
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public override string ToString()
    {
        return $"Предмет: {Name}, номер: {Number}";
    }
}