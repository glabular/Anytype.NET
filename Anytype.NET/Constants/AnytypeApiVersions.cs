namespace Anytype.NET.Constants;

public static class AnytypeApiVersions
{
    public const string V20250520 = "2025-05-20";
    public const string V20250422 = "2025-04-22";
    public const string V20250317 = "2025-03-17";

    /// <summary>
    /// Returns the latest known API version.
    /// </summary>
    public static string GetLatest() => V20250520;
}
