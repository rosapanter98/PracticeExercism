public static class ResistorColorDuo
{
    public static int Value(string[] colors)
{
    var digits = colors
        .Take(2)
        .Select(color => MapColorToDigit(color));

    string result = string.Concat(digits);
    return int.Parse(result);
}

private static string MapColorToDigit(string color) =>
    color.ToLowerInvariant() switch
    {
        "black" => "0",
        "brown" => "1",
        "red" => "2",
        "orange" => "3",
        "yellow" => "4",
        "green" => "5",
        "blue" => "6",
        "violet" => "7",
        "grey" => "8",
        "white" => "9",
        _ => throw new ArgumentException($"Invalid color: {color}")
    };

    
}
