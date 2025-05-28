using Domain.Core;

namespace Domain.Entities;

public class TodoTask : Entity
{
    public string Title { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsCompleted { get; private set; }

    public TodoTask() : base()
    {

    }
    public TodoTask(string title, DateTime dueDate) : base()
    {
        SetTitle(title);
        DueDate = dueDate;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (DateTime.Now > DueDate)
            throw new InvalidOperationException("Não é possível concluir tarefas vencidas.");
        IsCompleted = true;
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Título não pode ser vazio.");
        Title = title;
    }

    public void UpdateDueDate(DateTime newDate)
    {
        if (newDate < DateTime.Now)
            throw new ArgumentException("Data de vencimento não pode ser no passado.");
        DueDate = newDate;
    }
}