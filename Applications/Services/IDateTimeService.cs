namespace ZenOzHangfire.Applications.Services
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
    }
}