using Application.Services;

namespace UI.Actions;

public class CriarTarefaAction : IMenuAction
{
    private readonly TodoTaskService _service;

    public CriarTarefaAction(TodoTaskService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync()
    {
        Console.Write("Título: ");
        var title = Console.ReadLine();
        Console.Write("Data (yyyy-MM-dd): ");
        var dateInput = Console.ReadLine();
        if (DateTime.TryParse(dateInput, out var dueDate))
        {
            _service.CreateTask(title, dueDate);
            Console.WriteLine("Tarefa criada.");
        }
        else
        {
            Console.WriteLine("Data inválida.");
        }
    }
}

