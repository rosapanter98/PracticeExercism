public static class Pangram
{
    public static bool IsPangram(string sentence)
    {
        if (string.IsNullOrEmpty(sentence)) return false;

        var seen = new HashSet<char>();
        foreach (var ch in sentence.ToLowerInvariant())
        {
            if (ch >= 'a' && ch <= 'z')
            {
                seen.Add(ch);
                if (seen.Count == 26) return true;
            }
        }

        return seen.Count == 26;
    }
}