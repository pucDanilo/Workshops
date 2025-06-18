namespace Ex40.Services;

public class NotificationService
{
    public void SendEmail(string user, decimal amount)
    {
        Console.WriteLine($"Email sent to {user} regarding an amount of {amount:C}.");
    }

    public void SendSms(string user, decimal amount)
    {
        Console.WriteLine($"SMS sent to {user} regarding an amount of {amount:C}.");
    }

    public void SendPush(string user, decimal amount)
    {
        Console.WriteLine($"Push notification sent to {user} regarding an amount of {amount:C}.");
    }
}