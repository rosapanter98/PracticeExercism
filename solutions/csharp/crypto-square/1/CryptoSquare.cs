using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return Regex.Replace(plaintext.ToLowerInvariant(), "[^a-z0-9]", "");
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {

        string normalized = NormalizedPlaintext(plaintext);
        if (string.IsNullOrEmpty(normalized))
            yield break; // Return empty IEnumerable
    
        int length = normalized.Length;
        int row = 1, column;
    
        while (true)
        {
            column = (int)Math.Ceiling((double)length / row);
            if (column - row <= 1) break;
            row++;
        }
    
        normalized = normalized.PadRight(row * column);
    
        for (int i = 0; i < normalized.Length; i += column)
        {
            yield return normalized.Substring(i, column);
        }
    }


    public static string Encoded(string plaintext)
    {
        var segments = PlaintextSegments(plaintext).ToList();

        if (segments.Count == 0)
            return "";

        int columnCount = segments[0].Length;
        int rowCount = segments.Count;

        var encodedChunks = new List<string>();

        for (int col = 0; col < columnCount; col++)
        {
            string chunk = string.Concat(
                segments.Select(row => col < row.Length ? row[col] : ' ')
            );

            encodedChunks.Add(chunk);
        }

        return string.Join(" ", encodedChunks);
    }

    public static string Ciphertext(string plaintext)
    {
        var segments = PlaintextSegments(plaintext).ToList();
    
        if (segments.Count == 0)
            return "";
    
        int columnCount = segments[0].Length;
        int rowCount = segments.Count;
    
        var encodedChunks = new List<string>();
    
        for (int col = 0; col < columnCount; col++)
        {
            string chunk = string.Concat(
                segments.Select(row => col < row.Length ? row[col] : ' ')
            );
    
            encodedChunks.Add(chunk);
        }
    
        return string.Join(" ", encodedChunks);
    }
}
