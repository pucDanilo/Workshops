using Application.Services;

namespace UI.Actions;

public class ExcluirTarefaAction : IMenuAction
{
    private readonly TodoTaskService _service;

    public ExcluirTarefaAction(TodoTaskService service)
    {
        _service = service;
    }

    public async Task ExecuteAsync()
    {
        Console.Write("Id para excluir: ");
        var delIdStr = Console.ReadLine();
        if (Guid.TryParse(delIdStr, out var delId))
        {
            _service.DeleteTaskAsync(delId);
        }
    }
}

