using kpo_hw1.Animals;
using kpo_hw1.Interfaces;
using kpo_hw1.Things;

namespace kpo_hw1.ForZoo;
    
public class Zoo : IZoo
{
    private readonly List<Animal> _animals;
    private readonly List<Thing> _things;
    private readonly IVeterinaryClinic _clinic;

    public Zoo(IVeterinaryClinic clinic)
    {
        _animals = new List<Animal>();
        _things = new List<Thing>();
        _clinic = clinic;
    }
    
    public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();
    public IReadOnlyList<Thing> Things => _things.AsReadOnly();

    public void AddAnimal(Animal animal)
    {
        if (animal == null)
        {
            throw new ArgumentNullException(nameof(animal));
        }
        
        if (_clinic.CheckAnimal(animal))
        {
            _animals.Add(animal);
            Console.WriteLine($"Животное {animal.Name} добавлено в зоопарк.");
        }
        else
        {
            Console.WriteLine($"Животное {animal.Name} не здорово. Мы не можем его добавить в зоопарк.");
        }
    }

    public void AddThing(Thing thing)
    {
        if (thing == null)
        {
            throw new ArgumentNullException(nameof(thing));
        }
        
        _things.Add(thing);
        Console.WriteLine($"Предмет {thing.Name} добавлен в зоопарк.");
    }
}