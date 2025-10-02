namespace Workshop10_API.Api.Services
{
    public sealed class PerRequestClock : IPerRequestClock
    {
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
    }
}
