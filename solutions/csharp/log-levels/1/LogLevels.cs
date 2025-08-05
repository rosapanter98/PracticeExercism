static class LogLine
{
    public static string Message(string logLine)
    {
        string message= logLine
            .Trim()
            .Split(new[] { "]: "}, 2, StringSplitOptions.None)[1]
            .Trim();
        return message;
    }

    public static string LogLevel(string logLine)
    {
        string logLevel = logLine
            .Trim()
            .Split(new[] { "]: " }, 2, StringSplitOptions.None)[0]
            .Trim('[', ']')
            .ToLowerInvariant();
        return logLevel;
    }

    public static string Reformat(string logLine)
    {
        string logLevel = LogLevel(logLine);
        string message = Message(logLine);
        return $"{message} ({logLevel})";
    }
}
