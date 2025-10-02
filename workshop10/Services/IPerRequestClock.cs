namespace Workshop10_API.Api.Services
{
    public interface IPerRequestClock
    {
        // Carimbo criado no CONSTRUTOR (não muda depois)
        DateTimeOffset CreatedAt { get; }
    }
}
