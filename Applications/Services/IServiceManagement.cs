namespace ZenOzHangfire.Applications.Services
{
    public interface IServiceManagement
    {
        IDateTimeService DateTimeService { get; }
        ILoggingService LoggingService { get; }
    }
}