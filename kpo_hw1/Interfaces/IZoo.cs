using kpo_hw1.Animals;
using kpo_hw1.Things;

namespace kpo_hw1.Interfaces;

public interface IZoo
{
    IReadOnlyList<Animal> Animals { get; }
    IReadOnlyList<Thing> Things { get; }

    void AddAnimal(Animal animal);
    void AddThing(Thing thing);
}