using ZenOzHangfire.Applications.Jobs;
using ZenOzHangfire.Applications.Services;

namespace ZenOzHangfire.Infrastructure.Jobs
{
    public class SampleRecurringJob : ISampleRecurringJob
    {
        public const string JOB_NAME = nameof(SampleRecurringJob);
        private readonly IServiceManagement _serviceManagement;

        public SampleRecurringJob(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        public void Execute(params object[] parameters)
        {
            _serviceManagement.LoggingService.LogInformation($"{JOB_NAME} executed at {_serviceManagement.DateTimeService.Now}");
        }
    }
}