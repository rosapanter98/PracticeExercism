public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word)) return true;

        Span<bool> seen = stackalloc bool[26];
        int count = 0;

            foreach (char ch in word)
            {
                char lower = char.ToLowerInvariant(ch);
                if(lower >= 'a' && lower <= 'z')
                {
                    int idx = lower - 'a';
                    if (seen[idx]) return false;
                    seen[idx] = true;
                }
            }
        return true;
    }
}
