namespace ZenOzHangfire.Applications.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogDebug(string message);
    }
}