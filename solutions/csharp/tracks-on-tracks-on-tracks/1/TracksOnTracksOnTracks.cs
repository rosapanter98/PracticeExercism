public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        var list = new List<string>();
        list.Add("C#");
        list.Add("Clojure");
        list.Add("Elm");
        return list;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
         
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages == null || languages.Count == 0)
            return false;
    
        // Rule 1: First language is C#
        if (languages[0] == "C#")
            return true;
    
        // Rule 2: Second language is C# and list has 2 or 3 items
        if (languages.Count >= 2 && languages[1] == "C#" && languages.Count <= 3)
            return true;
    
        return false;
    }


    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var seen = new HashSet<string>();
        foreach (var lang in languages)
        {
            if (!seen.Add(lang)) // Add returns false if already present
                return false;
        }
        return true;
    }
}
