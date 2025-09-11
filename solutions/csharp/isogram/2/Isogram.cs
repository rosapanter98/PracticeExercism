public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word)) return true;

        int mask = 0;
        foreach (char ch in word)
        {
            char lower = char.ToLowerInvariant(ch);
            if(lower >= 'a' && lower <= 'z')
            {
                int bit = 1 << (lower - 'a');
                if ((mask & bit) != 0) return false;
                mask |= bit;
            }
        }
        return true;
    }
}
