public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        // Expected format: "631-555-1234"
        var parts = phoneNumber.Split('-');
        bool isNewYork = parts[0] == "212";
        bool isFake = parts[1] == "555";
        string localNumber = parts[2];
        return (isNewYork, isFake, localNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) info) =>
        info.IsFake;

    public static bool IsNewYork((bool IsNewYork, bool IsFake, string LocalNumber) info) =>
        info.IsNewYork;

    public static string LocalNumber((bool IsNewYork, bool IsFake, string LocalNumber) info) =>
        info.LocalNumber;
}
