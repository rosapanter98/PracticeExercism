public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiter){
       if(str == null || delimiter == null)
           return str;

        int index = str.IndexOf(delimiter, StringComparison.Ordinal);
        if (index < 0)
            return str;

        return str.Substring(index+delimiter.Length);
    }

    public static string SubstringBetween(this string str, string start, string end)
    {
        if (str == null || start == null || end == null)
            return str;
    
        int firstIndex = str.IndexOf(start, StringComparison.Ordinal);
        if (firstIndex < 0)
            return str;
    
        firstIndex += start.Length;
    
        int secondIndex = str.IndexOf(end, firstIndex, StringComparison.Ordinal);
        if (secondIndex < 0)
            return str;
    
        return str.Substring(firstIndex, secondIndex - firstIndex);
    }

    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log)
    {
        const string delimiter = ": ";
        if (log == null)
            return null;

        int index = log.IndexOf(delimiter, StringComparison.Ordinal);
        if (index < 0)
            return log;

        return log.Substring(index + delimiter.Length);
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string log)
    {
        const string delimiter = ":";
        if (log == null)
            return null;

        int index = log.IndexOf(delimiter, StringComparison.Ordinal);
        if (index < 0)
            return log;

        return log.Substring(0,index).Trim().Replace("[","").Replace("]","");
    }
}