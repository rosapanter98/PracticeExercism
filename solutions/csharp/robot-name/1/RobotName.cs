using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random _rand = new Random();
    private static readonly HashSet<string> _usedNames = new HashSet<string>();
    private string? _name;

    public string Name
    {
        get
        {
            if (_name == null)
            {
                _name = GenerateUniqueName();
            }
            return _name;
        }
    }

    public void Reset()
    {
        _usedNames.Remove(_name!);
        _name = null;
    }

    private static string GenerateUniqueName()
    {
        string name;
        do
        {
            name = $"{RandomLetter()}{RandomLetter()}{_rand.Next(0, 1000):D3}";
        } while (!_usedNames.Add(name));
        return name;
    }

    private static char RandomLetter()
    {
        return (char)('A' + _rand.Next(0, 26));
    }
}
