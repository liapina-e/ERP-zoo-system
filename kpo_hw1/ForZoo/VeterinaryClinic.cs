using kpo_hw1.Animals;
using kpo_hw1.Interfaces;

namespace kpo_hw1.ForZoo;

public class VeterinaryClinic : IVeterinaryClinic
{
    public bool CheckAnimal(Animal animal)
    {
        if (animal == null)
        {
            throw new ArgumentNullException(nameof(animal), "Animal can't be null");
        }
        
        if (animal.Health == "healthy")
        {
            return true;
        }
        return false;
    }
    
    
}

