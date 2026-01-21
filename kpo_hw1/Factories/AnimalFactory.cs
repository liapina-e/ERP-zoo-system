using kpo_hw1.Animals;
using Microsoft.Extensions.DependencyInjection;

namespace kpo_hw1.Factories;

public class AnimalFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    private static readonly Dictionary<string, Type> _animalTypes = new()
    {
        { "1", typeof(Monkey) },
        { "2", typeof(Rabbit) },
        { "3",  typeof(Tiger)  },
        { "4",   typeof(Wolf)   }
    };

    public AnimalFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public Animal Create(string animalType)
    {
        string key = (animalType ?? "").Trim();

        if (!_animalTypes.TryGetValue(key, out Type? type))
        {
            throw new ArgumentException($"Неизвестный тип животного: {animalType}");
        }

        return (Animal)_serviceProvider.GetRequiredService(type);
    }
}