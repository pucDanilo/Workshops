namespace Workshop10_API.Api.Services
{
    public sealed class ReportingSingleton
    {
        private readonly IPerRequestClock _clock;

        public ReportingSingleton(IPerRequestClock clock)
        {
            _clock = clock;
        }

        public DateTimeOffset GetClockCreatedAt()
        {
            return _clock.CreatedAt;
        }
    }
}
