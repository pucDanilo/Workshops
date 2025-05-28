using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace UI;

public static class MeuContextoFactory
{
    public static MeuDbContext instance;

    static MeuContextoFactory()
    {
        var _contextOptions = new DbContextOptionsBuilder<MeuDbContext>()
            .UseInMemoryDatabase("InMemoryRepositoryy")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        instance = new MeuDbContext(_contextOptions);

        instance.Database.EnsureDeleted();
        instance.Database.EnsureCreated();

        instance.AddRange(
            new TodoTask("Blog1", DateTime.Now),
            new TodoTask("Blog2", DateTime.Now.AddDays(2)),
            new TodoTask("Blog21", DateTime.Now.AddDays(21))
        );

        instance.SaveChanges();
    }
}

/*
ITodoTaskRepository repo = new InMemoryTodoTaskRepository(Contexto.instance);
    var service = new TodoTaskService(repo);

    while (true)
    {
        Console.WriteLine("1. Criar Tarefa");
        Console.WriteLine("2. Listar Tarefas");
        Console.WriteLine("3. Concluir Tarefa");
        Console.WriteLine("4. Listar Tarefas Vencidas");
        Console.WriteLine("5. Excluir Tarefa");
        Console.WriteLine("0. Sair");
        Console.Write("Opção: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Título: ");
                var title = Console.ReadLine();
                Console.Write("Data (yyyy-MM-dd): ");
                var dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out var dueDate))
                {
                    service.CreateTask(title, dueDate);
                    Console.WriteLine("Tarefa criada.");
                }
                else
                    Console.WriteLine("Data inválida.");
                break;

            case "2":
                foreach (var t in await service.GetAllTasksAsync())
                    Console.WriteLine($"{t.Id} | {t.Title} | {t.DueDate:yyyy-MM-dd} | Concluída: {t.IsCompleted}");
                break;

            case "3":
                Console.Write("Id: ");
                var idStr = Console.ReadLine();
                if (Guid.TryParse(idStr, out var id))
                {
                    service.CompleteTask(id);
                    Console.WriteLine("Concluída.");
                }
                break;

            case "4":
                Console.WriteLine("Tarefas vencidas:");
                foreach (var t in await service.GetOverdueTasksAsync())
                    Console.WriteLine($"{t.Id} | {t.Title} | {t.DueDate:yyyy-MM-dd} | Concluída: {t.IsCompleted}");
                break;

            case "5":
                Console.Write("Id para excluir: ");
                var delIdStr = Console.ReadLine();
                if (Guid.TryParse(delIdStr, out var delId))
                {
                    service.DeleteTaskAsync(delId);
                }
                break;

            case "0":
                return;
        }

        Console.WriteLine();
    }*/