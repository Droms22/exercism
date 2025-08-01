using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var appointmentDate = DateTime.Parse(appointmentDateDescription);
        return TimeZoneInfo.ConvertTimeToUtc(appointmentDate, GetTimeZoneInfo(location));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
                AlertLevel.Early => appointment - new TimeSpan(24, 0, 0),
                AlertLevel.Standard => appointment - new TimeSpan(1, 45, 0),
                AlertLevel.Late => appointment - new TimeSpan(0, 30, 0)
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZone = GetTimeZoneInfo(location);
        for (int i = 0; i < 7 ; i++)
        {
            var dateToCheck = dt.AddDays(-i);
            if (timeZone.IsDaylightSavingTime(dateToCheck) != timeZone.IsDaylightSavingTime(dateToCheck.AddDays(1)))
            {
                return true;
            }
        }
        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var result = new DateTime(1, 1, 1);
        DateTime.TryParse(dtStr, GetCultureInfo(location), DateTimeStyles.None, out result);
        return result;
    }

    public static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        var isWindows = OperatingSystem.IsWindows();
        return location switch
        {
            Location.NewYork when isWindows => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
            Location.London when isWindows => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
            Location.Paris when isWindows => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
            Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris")
        };
    }

    public static CultureInfo GetCultureInfo(Location location)
    {
        return location switch
        {
            Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
            Location.London => CultureInfo.GetCultureInfo("en-GB"),
            Location.Paris => CultureInfo.GetCultureInfo("fr-FR")
        };
    }
}
