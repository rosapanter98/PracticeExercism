using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        var s = (statement ?? "").Trim();

        bool isSilent   = s.Length == 0;
        bool hasLetters = s.Any(char.IsLetter);
        bool isYelling  = hasLetters && s == s.ToUpperInvariant();
        bool isQuestion = s.EndsWith("?");

        return (isSilent, isYelling, isQuestion) switch
        {
            (true,  _,     _)    => "Fine. Be that way!",
            (false, true,  true)  => "Calm down, I know what I'm doing!",
            (false, true,  false) => "Whoa, chill out!",
            (false, false, true)  => "Sure.",
            _                     => "Whatever.",
        };
    }
}
