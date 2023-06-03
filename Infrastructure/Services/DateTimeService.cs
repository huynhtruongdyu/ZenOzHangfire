﻿using ZenOzHangfire.Applications.Services;

namespace ZenOzHangfire.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime Now => DateTime.Now;
    }
}