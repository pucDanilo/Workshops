namespace UI.Actions;

public class SairAction : IMenuAction
{
    public SairAction()
    {
    }

    public async Task ExecuteAsync()
    {
        //TODO -- Refatorar
        Program.running = false;
    }
}

