namespace ZenOzHangfire.Options
{
    public class GlobalAppSetting
    {
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public Hangfire Hangfire { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
        public string Hangfire { get; set; }
    }

    public class Connectionstrings
    {
        public string HangfireConnection { get; set; }
    }

    public class Hangfire
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}