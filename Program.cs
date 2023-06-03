using Hangfire;

using ZenOzHangfire.Applications.Jobs;
using ZenOzHangfire.Applications.Services;
using ZenOzHangfire.Infrastructure;
using ZenOzHangfire.Infrastructure.Jobs;
using ZenOzHangfire.Infrastructure.Services;
using ZenOzHangfire.Options;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.Configure<GlobalAppSetting>(opt => builder.Configuration.Bind(opt));
    builder.Services.AddScoped<IServiceManagement, ServiceManagement>();
    builder.Services.AddScoped<ISampleRecurringJob, SampleRecurringJob>();

#if DEBUG
    builder.Services.AddHangfire(x => x.UseInMemoryStorage());
#else
    builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));
#endif
    builder.Services.AddHangfireServer();
}

var app = builder.Build();
{
    GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(app.Services));

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseHangfireDashboard("/dashboard", null, null);
    RecurringJob.AddOrUpdate<ISampleRecurringJob>("1", ps => ps.Execute(), Cron.Minutely);

    app.Run();
}