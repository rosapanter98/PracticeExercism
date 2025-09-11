static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var dept = department is null ? "OWNER" : department.ToUpperInvariant();
        return id is int i ? $"[{i}] - {name} - {dept}" : $"{name} - {dept}";
    }
}

