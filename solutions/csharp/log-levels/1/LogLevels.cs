static class LogLine
{
    public static string Message(string logLine) => 
        logLine.Split(": ", 2)[1].Trim();

    public static string LogLevel(string logLine) =>
        logLine.Split(']')[0]
                      .TrimStart('[')
                      .ToLowerInvariant();

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}
