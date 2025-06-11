// See https://aka.ms/new-console-template for more information
using CandyFactory;
using CandyFactory.Models;
using CandyFactory.Monitoring;

Console.WriteLine("Hello, World!");

var line = new MachineLine<CandyMachine>();
line.Add(new ChocolateMachine("ChocoMaster", 50));
line.Add(new GummyMachine("GummyDelight", 60));
line.Add(new ChocolateMachine("CocoaPro", 30));
line.Add(new LollipopMachineBatch("Foo", 10));
line.Add(new LollipopMachine("Bar", 13));

Console.WriteLine("== TURN0 ==");
line.OperateAll();

Console.WriteLine("\n== BOOST ==");
foreach (var m in line.GetMachines()) m.BoostCapacity(25);

Console.WriteLine("\n== TURN1 ==");
line.OperateAll();

Console.WriteLine("\n== LIMPEZA ==");
foreach (var m in line.GetMachines()) m.CleanUp();

new FactoryMonitor(line).GenerateReport();