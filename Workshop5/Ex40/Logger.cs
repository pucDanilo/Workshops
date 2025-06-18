namespace Ex40;

public class Logger
{
    private void Log(string level, string message)
    {
        Console.WriteLine($"[{level} {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
    }

    public void LogInfo(string message)
    {
        Log("INFO", message);
    }

    public void LogError(string message)
    {
        Log("ERROR", message);
    }
}