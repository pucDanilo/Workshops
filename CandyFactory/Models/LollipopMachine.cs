namespace CandyFactory.Models;
public class LollipopMachine : CandyMachine
{
    public LollipopMachine(string name, int capacity) : base(name, capacity)
    {
    }

    public override void Produce()
    {
        Console.WriteLine($"{MachineName} produzindo pirulitos...");
        WrapLollipops(); 
    }
     
    private void WrapLollipops() => Console.WriteLine($"{MachineName}: pirulitos embrulhados!");
}