namespace Workshops.Domain.Models;

public class Marcacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid IdRegistro { get; set; }
    public string entrada { get; set; }
    public string saida { get; set; }
    public string total { get; set; }
}

