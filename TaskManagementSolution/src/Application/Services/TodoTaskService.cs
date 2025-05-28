using Domain;
using Domain.Entities;

namespace Application.Services;

public class TodoTaskService
{
    private readonly ITodoTaskRepository _repository;

    public TodoTaskService(ITodoTaskRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateTask(string title, DateTime dueDate)
    {
        var task = new TodoTask(title, dueDate);
        await _repository.Add(task);
    }

    public async void CompleteTask(Guid id)
    {
        var task = await _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Tarefa com id {id} não encontrada.");
        task.Complete();
        _repository.Update(task);
    }

    public async Task<IEnumerable<TodoTask>> GetAllTasksAsync() => await _repository.ListAll();

    public async Task<IEnumerable<TodoTask>> GetOverdueTasksAsync()
    {
        return await _repository.GetOverdueTasks();
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        await _repository.Remove(id);
    }
}