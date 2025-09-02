using System.Globalization;

namespace NoCast.App.Common.Statics
{
    public static class DateTimeExtensions
    {
        private static readonly PersianCalendar _persianCalendar = new PersianCalendar();
        public static string ToRelativeTime(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var diff = now - dateTime;

            if (diff.TotalHours < 24) {
                if (diff.TotalSeconds < 60)
                    return "لحظاتی پیش";

                if (diff.TotalMinutes < 60)
                    return $"{(int)diff.TotalMinutes} دقیقه پیش";

                if (diff.TotalHours < 24 && dateTime.Date == now.Date)
                    return $"{(int)diff.TotalHours} ساعت پیش";
            }

            var year = _persianCalendar.GetYear(dateTime);
            var month = _persianCalendar.GetMonth(dateTime);
            var day = _persianCalendar.GetDayOfMonth(dateTime);
            var hour = _persianCalendar.GetHour(dateTime);
            var minute = _persianCalendar.GetMinute(dateTime);
            return $"{year:0000}/{month:00}/{day:00} {hour:00}:{minute:00}";

        }
        public static string ToRelativeDate(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var diff = now - dateTime;

            if (diff.TotalHours < 24 && dateTime.Date == now.Date)
                return "امروز";

            if (dateTime.Date == now.Date.AddDays(-1))
                return "دیروز";

            if (diff.TotalDays < 7)
                return $"{(int)diff.TotalDays} روز پیش";

            if (diff.TotalDays < 30)
                return $"{(int)(diff.TotalDays / 7)} هفته پیش";

            if (diff.TotalDays < 365)
                return $"{(int)(diff.TotalDays / 30)} ماه پیش";

            return $"{(int)(diff.TotalDays / 365)} سال پیش";
        }
    }

}
