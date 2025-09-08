using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier)) return string.Empty;

        var sb = new StringBuilder(identifier.Length);
        bool capitalizeNext = false;

        foreach (var c in identifier)
        {
            if (char.IsControl(c)) { sb.Append("CTRL"); capitalizeNext = false; continue; }
            if (c == ' ')        { sb.Append('_');     capitalizeNext = false; continue; }
            if (c == '-')        { capitalizeNext = true;                      continue; }
            if (IsLowerGreek(c)) { capitalizeNext = false;                     continue; }
            if (!char.IsLetter(c)) { capitalizeNext = false;                   continue; }

            sb.Append(capitalizeNext ? char.ToUpperInvariant(c) : c);
            capitalizeNext = false;
        }

        return sb.ToString();
    }

    private static bool IsLowerGreek(char c) => c >= 'α' && c <= 'ω';
}
