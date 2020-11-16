using System;

namespace UtcDateTime
{
  public struct UtcDateTime
  {
    public static TimeZoneInfo LocalTimeZoneInfo { get; set; } = TimeZoneInfo.Local;

    private DateTime _utcDateTime;
    
    public UtcDateTime(DateTime dateTime, TimeZoneInfo timeZoneInfo = null) : this()
    {
      if (timeZoneInfo == null && dateTime.Kind != DateTimeKind.Utc)
        dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
      if (timeZoneInfo != null && dateTime.Kind == DateTimeKind.Utc)
        dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Local);

      _utcDateTime =  timeZoneInfo != null
        ? TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo)
        : dateTime;
    }
    public UtcDateTime(DateTime dateTime, bool useLocalTime) : this(dateTime, useLocalTime ? LocalTimeZoneInfo : null) { }

    public DateTime GetDateTime(TimeZoneInfo timeZoneInfo = null)
    {
      if (timeZoneInfo == null || timeZoneInfo == TimeZoneInfo.Utc)
        return _utcDateTime;

      return TimeZoneInfo.ConvertTimeFromUtc(_utcDateTime, timeZoneInfo);
    }
    public DateTime GetDateTimeLocal()
    {
      return TimeZoneInfo.ConvertTimeFromUtc(_utcDateTime, LocalTimeZoneInfo);
    }
  }
}
