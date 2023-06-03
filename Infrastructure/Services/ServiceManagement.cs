using ZenOzHangfire.Applications.Services;

namespace ZenOzHangfire.Infrastructure.Services
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IDateTimeService> _dateTimeService;
        private readonly Lazy<ILoggingService> _loggingService;

        public ServiceManagement(ILogger<ServiceManagement> logger)
        {
            _dateTimeService = new Lazy<IDateTimeService>(() => new DateTimeService());
            _loggingService = new Lazy<ILoggingService>(() => new LoggingService(logger));
        }

        public IDateTimeService DateTimeService => _dateTimeService.Value;

        public ILoggingService LoggingService => _loggingService.Value;
    }
}