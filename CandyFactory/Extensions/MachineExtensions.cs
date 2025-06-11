using CandyFactory.Models;

namespace CandyFactory
{
    public static class MachineExtensions
    {
        public static List<T> FilterByCapacity<T>(this List<T> machines, int min) where T : CandyMachine
        {
            var result = new List<T>();
            foreach (var machine in machines)
            {
                if (machine.Capacity >= min)
                {
                    result.Add(machine);
                }
            }
            return result;
        }

        // Aumenta capacidade até 100 %
        public static void BoostCapacity(this CandyMachine machine, int amount)
        {
            machine.Capacity = machine.Capacity + amount > 100
                ? 100
                : machine.Capacity + amount;

            Console.WriteLine($"{machine.MachineName} agora em {machine.Capacity}%");
        }
    }
}