namespace CandyFactory.Models;
public class ChocolateMachine : CandyMachine
{
    public ChocolateMachine(string name, int capacity)
        : base(name, capacity) { }

    public override void Produce()
    {
        if (Capacity < 10)
        {
            Console.WriteLine($"{MachineName} sem capacidade! Reabasteça primeiro.");
            return;
        }

        Console.WriteLine($"{MachineName} produzindo chocolate...");
        TemperChocolate();

        ConsumeCapacity(10);
    }

    // Método exclusivo
    public void TemperChocolate() =>
        Console.WriteLine($"{MachineName}: chocolate temperado!");

    public override string Status() =>
        base.Status() + " (Chocolate pronto)";
}
