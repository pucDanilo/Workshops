using Application.Services;

namespace UI.Actions;

public class ConcluirTarefaAction : IMenuAction
{
    private readonly TodoTaskService _service;

    public ConcluirTarefaAction(TodoTaskService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync()
    {
        Console.Write("Id: ");
        var idStr = Console.ReadLine();
        if (Guid.TryParse(idStr, out var id))
        {
            _service.CompleteTask(id);
            Console.WriteLine("Concluída.");
        }
    }
}

