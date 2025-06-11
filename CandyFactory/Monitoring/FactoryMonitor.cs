using CandyFactory.Models;

namespace CandyFactory.Monitoring
{
    public class FactoryMonitor
    {
        private List<CandyMachine> machines;
        private int sumCapacity;
        private double averageCapacity;
        private CandyMachine maxCapacityMachine;
        private int totalMachines;
        private int currentMachine;

        public FactoryMonitor(MachineLine<CandyMachine> machineLine)
        {
            //_machineLine = machineLine;
            machines = machineLine.GetMachines();
            this.sumCapacity = 0;
            this.maxCapacityMachine = machines[0];
            this.totalMachines = machines.Count();
            this.currentMachine = 0;
            NextMachine( );
        }

        private void NextMachine()
        {
            var current = machines[currentMachine];
            this.sumCapacity += current.Capacity;
            if (current.Capacity > maxCapacityMachine.Capacity)
            {
                maxCapacityMachine = current;
            }
            currentMachine++;
            if (currentMachine < totalMachines)
                NextMachine( );
            else
                averageCapacity = sumCapacity / totalMachines;
        }

        public void GenerateReport()
        {

            Console.WriteLine("== Factory Report ==");
            Console.WriteLine($"Capacidade m�dia das m�quinas: {averageCapacity:F2}");
            Console.WriteLine($"Nome e capacidade da m�quina com maior capacidade: {maxCapacityMachine.MachineName} ({maxCapacityMachine.Capacity})");
            Console.WriteLine($"N�mero total de m�quinas na linha de produ��o: {totalMachines}");
        }
    }
}