using Application.Services;

namespace UI.Actions;

public class ListarTarefasAction : IMenuAction
{
    private readonly TodoTaskService _service;

    public ListarTarefasAction(TodoTaskService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync()
    {
        var tasks = await _service.GetAllTasksAsync();
        foreach (var t in tasks)
            Console.WriteLine($"{t.Id} | {t.Title} | {t.DueDate:yyyy-MM-dd} | Concluída: {t.IsCompleted}");
    }
}

