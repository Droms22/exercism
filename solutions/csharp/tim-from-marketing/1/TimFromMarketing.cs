using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string badge = id == null ? "" : $"[{id}] - ";
        badge += name;
        badge += department == null ? " - OWNER" : $" - {department.ToUpper()}";
        return badge;
    }
}
