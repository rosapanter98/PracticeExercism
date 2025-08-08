using System.Globalization;
using System.Linq;

using System;
using System.Globalization;
using System.Linq;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder(identifier.Length);

        for (int i = 0; i < identifier.Length; i++)
        {
            char c = identifier[i];

            // 1. Replace spaces with underscores
            if (c == ' ')
            {
                sb.Append('_');
                continue;
            }

            // 2. Replace control characters with "CTRL"
            if (char.IsControl(c))
            {
                sb.Append("CTRL");
                continue;
            }

            // 3. Convert kebab-case to camelCase
            if (c == '-' && i + 1 < identifier.Length)
            {
                sb.Append(char.ToUpper(identifier[i + 1], CultureInfo.InvariantCulture));
                i++; // skip the next char
                continue;
            }

            // 4. Omit any non-letters
            if (!char.IsLetter(c))
                continue;

            // 5. Omit Greek letters in range α..ω
            if (c >= 'α' && c <= 'ω')
                continue;

            sb.Append(c);
        }

        return sb.ToString();
    }
}
