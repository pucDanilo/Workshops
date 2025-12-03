namespace Workshops.Domain.Models;

public class Registro
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string data { get; set; }
    public string status { get; set; }
    public Marcacao[] marcacoes { get; set; }
    public string userId { get; set; }
}

