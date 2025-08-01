using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(':')+1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        return logLine.Substring(logLine.IndexOf('[')+1,logLine.IndexOf(']')-1).ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{LogLine.Message(logLine)} ({LogLine.LogLevel(logLine)})";
    }
}
