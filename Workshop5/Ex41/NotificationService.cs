using Ex41.Interfaces;

namespace Ex41;

public class NotificationService : INotificationService
{
    public void Send(string message, string type)
    {
        if (type == "Email")
        {
            Console.WriteLine($"Enviando email: {message}");
        }
        else if (type == "SMS")
        {
            Console.WriteLine($"Enviando SMS: {message}");
        }
        else
        {
            Console.WriteLine($"Notificação ({type}) não implementada");
        }
    }
}