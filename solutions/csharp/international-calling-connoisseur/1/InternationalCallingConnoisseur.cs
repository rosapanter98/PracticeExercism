public static class DialingCodes
{
    private static Dictionary<int, string> _dialingCodes = new Dictionary<int, string>
    {
        {1, "United States of America"},
        {55, "Brazil"},
        {91, "India"}
    };
        
    
    public static Dictionary<int, string> GetEmptyDictionary() =>
        new();

    public static Dictionary<int, string> GetExistingDictionary() =>
         new Dictionary<int, string>(_dialingCodes);

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) =>
         new Dictionary<int, string> {[countryCode] = countryName};

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.TryAdd(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.TryGetValue(countryCode, out var country)
            ? country
            : "";
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
    Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }


    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
{
    string longest = string.Empty;

    foreach (var kvp in existingDictionary)
    {
        if (kvp.Value.Length > longest.Length)
        {
            longest = kvp.Value;
        }
    }
    return longest;
 }
}