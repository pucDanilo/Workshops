namespace CandyFactory.Models
{
    public abstract class CandyMachine
    {
        public string MachineName { get; }
        private int _capacity;     // 0-100 %

        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Capacity deve estar entre 0 e 100.");
                _capacity = value;
            }
        }

        protected CandyMachine(string machineName, int capacity)
        {
            MachineName = machineName;
            Capacity = capacity;
        }

        // Cada máquina define sua própria produção
        public abstract void Produce();

        // Mostra a capacidade atual (muda a cada produção!)
        public virtual string Status() =>
            $"{MachineName}: capacidade {Capacity}%";

        public virtual void Batch(int count)
        {
            Console.WriteLine($"--------------Batch");
            for (int i = 1; i <= count; i++)
            {
                Produce();
                Console.WriteLine($"Batch {i} de {count} concluído.");
            }
            Console.WriteLine($"--------------End Batch");
        }
        // Reduz capacidade depois de produzir
        protected void ConsumeCapacity(int amount)
        {
            if ((Capacity - amount) < 0)
            {
                Console.WriteLine($"Não é possível produzir o lote. Capacidade insuficiente.");
                return;
            }
            Capacity = Capacity - amount;
        }

        // Limpeza padrão
        public void CleanUp() =>
            Console.WriteLine($"{MachineName} passou pela limpeza padrão.");
    }
}