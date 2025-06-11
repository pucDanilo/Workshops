namespace CandyFactory.Models;

public class GummyMachine : CandyMachine
{
    public GummyMachine(string name, int capacity) : base(name, capacity)
    {
    }

    public override void Produce()
    {
        if (Capacity < 5)
        {
            Console.WriteLine($"{MachineName} sem capacidade! Reabasteça primeiro.");
            return;
        }

        Console.WriteLine($"{MachineName} produzindo gomas...");
        ShapeGummies();

        ConsumeCapacity(5);
    }

    public void ShapeGummies() =>
        Console.WriteLine($"{MachineName}: gomas moldadas!");
}