using Application.Services;

namespace UI.Actions;

public class ListarVencidasAction : IMenuAction
{
    private readonly TodoTaskService _service;

    public ListarVencidasAction(TodoTaskService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Tarefas vencidas:");
        foreach (var t in await _service.GetOverdueTasksAsync())
            Console.WriteLine($"{t.Id} | {t.Title} | {t.DueDate:yyyy-MM-dd} | Concluída: {t.IsCompleted}");
    }
}

