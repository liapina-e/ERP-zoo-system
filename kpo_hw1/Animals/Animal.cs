using kpo_hw1.Interfaces;

namespace kpo_hw1.Animals;

public abstract class Animal: IAlive, IInventory
{
    public int Food { get; set; }
    public int Number { get; set; }
    public abstract string Name { get; }

    private string _health = "healthy";

    public string? Health
    {
        get => _health;
        set
        {
            if (value != "healthy" && value != "sick")
            {
                throw new ArgumentException("Здоровье должны иметь вид 'healthy' или 'sick'");
            }
            _health = value;
        }
    }

    public override string ToString()
    {
        return $"Животное: {Name}, номер: {Number}";
    }
}