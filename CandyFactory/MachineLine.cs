using CandyFactory.Interfaces;
using CandyFactory.Models;

public class MachineLine<T> where T : CandyMachine
{
    private readonly List<T> _machines = new();

    public void Add(T machine) => _machines.Add(machine);

    public void OperateAll()
    {
        foreach (var machine in _machines)
        {
            if (machine is IBatchable batchableMachine)
            {
                Console.WriteLine($"Batchable Machine: {machine.Status()}");
                batchableMachine.Batch(3);
            }
            else
            {
                Console.WriteLine(machine.Status());
                machine.Produce();
            }
        }
    }

    public List<T> GetMachines() => _machines;
}