
namespace Animals;


public class Program
{
    static void Main()
    {
        var dog = new GermanShepard("Bello",12);

        var cat = new Cat("Minka", 5);


        List<Animal> animals = [dog, cat];

        animals.ForEach(a => a.MakeSound());

        animals.OfType<Dog>().ToList().ForEach(d => d.GetRace());
    }
}