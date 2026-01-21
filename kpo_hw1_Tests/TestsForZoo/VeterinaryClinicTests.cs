using kpo_hw1.Animals;
using kpo_hw1.ForZoo;
using kpo_hw1.Interfaces;

namespace kpo_hw1_Tests.TestsForZoo;

public class VeterinaryClinicTests
{
    [Fact]
    public void CheckAnimal_AnimalWithHealthyStatus_ReturnsTrue()
    {
        IVeterinaryClinic clinic = new VeterinaryClinic();
        Monkey healthyMonkey = new Monkey { Health = "healthy" };
        bool result = clinic.CheckAnimal(healthyMonkey);
        Assert.True(result);
    }

    [Fact]
    public void CheckAnimal_AnimalWithSickStatus_ReturnsFalse()
    {
        IVeterinaryClinic clinic = new VeterinaryClinic();
        Tiger sickTiger = new Tiger { Health = "sick" };
        bool result = clinic.CheckAnimal(sickTiger);
        Assert.False(result);
    }

    [Fact]
    public void CheckAnimal_SettingInvalidHealth_ThrowsArgumentException()
    {
        Wolf wolf = new Wolf();
        ArgumentException ex = Assert.Throws<ArgumentException>(() => wolf.Health = "unknown");
        Assert.Equal("Здоровье должны иметь вид 'healthy' или 'sick'", ex.Message);
    }


    [Fact]
    public void CheckAnimal_NullAnimal_ThrowsArgumentNullException()
    {
        IVeterinaryClinic clinic = new VeterinaryClinic();
    
        var exception = Assert.Throws<ArgumentNullException>(() => clinic.CheckAnimal(null!));
    
        Assert.Equal("animal", exception.ParamName);
    }
}