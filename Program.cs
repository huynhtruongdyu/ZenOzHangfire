using Hangfire;

using ZenOzHangfire.Options;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.Configure<GlobalAppSetting>(opt => builder.Configuration.Bind(opt));

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
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseHangfireDashboard("/dashboard", null, null);

    app.Run();
}