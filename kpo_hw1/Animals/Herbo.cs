namespace kpo_hw1.Animals;

public abstract class Herbo : Animal
{
    public int LevelOfKindness {get; set;}

    public bool CanContactWithPeople()
    {
        return LevelOfKindness > 5;
    }
}