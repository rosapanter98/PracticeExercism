static class Badge
{
public static string Print(int? id, string name, string? department)
{
    var dept = string.IsNullOrWhiteSpace(department) ? "OWNER" : department.ToUpperInvariant();
    return id.HasValue
        ? $"[{id.Value}] - {name} - {dept}"
        : $"{name} - {dept}";
}


}
