public static class Pangram
{
    public static bool IsPangram(string sentence)
    {
        if (string.IsNullOrEmpty(sentence)) return false;

        Span<bool> seen = stackalloc bool[26]; // fixed-size, no heap alloc
        int count = 0;

        foreach (char ch in sentence)
        {
            char lower = char.ToLowerInvariant(ch);
            if (lower >= 'a' && lower <= 'z')
            {
                int idx = lower - 'a';
                if (!seen[idx])
                {
                    seen[idx] = true;
                    count++;
                    if (count == 26) return true;
                }
            }
        }

        return count == 26;
    }
}
