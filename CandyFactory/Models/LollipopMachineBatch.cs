using CandyFactory.Interfaces;

namespace CandyFactory.Models;

public class LollipopMachineBatch : LollipopMachine, IBatchable
{
    public LollipopMachineBatch(string machineName, int capacity) : base(machineName, capacity)
    {
    }
     
}
