using System;

namespace WpfNotifications.Utilities
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetLocalDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetUtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}