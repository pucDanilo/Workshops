using Application.Services;
using Domain;
using Infrastructure.Repositories;
using UI.Actions;

namespace UI;

public class Program
{
    public static bool running = true;

    private static async Task Main()
    {
        ITodoTaskRepository repo = new TodoTaskRepository(MeuContextoFactory.instance);
        var service = new TodoTaskService(repo);

        var actions = new Dictionary<string, IMenuAction>
        {
            ["1"] = new CriarTarefaAction(service),
            ["2"] = new ListarTarefasAction(service),
            ["3"] = new ConcluirTarefaAction(service),
            ["4"] = new ListarVencidasAction(service),
            ["5"] = new ExcluirTarefaAction(service),
            ["0"] = new SairAction()
        };

        while (running)
        {
            Console.WriteLine("Danps Corporate");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Concluir Tarefa");
            Console.WriteLine("4. Listar Tarefas Vencidas");
            Console.WriteLine("5. Excluir Tarefa");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            var option = Console.ReadLine();

            if (actions.TryGetValue(option, out var action))
            {
                await action.ExecuteAsync();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}