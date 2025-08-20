using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        input = input.ToUpperInvariant();

        foreach (char c in AllLetters())
        {
            if (!input.Contains(c))
                return false;
        }

        return true;
    }

    private static IEnumerable<char> AllLetters()
    {
        for (char c = 'A'; c <= 'Z'; c++)
        {
            yield return c;
        }
    }
}
