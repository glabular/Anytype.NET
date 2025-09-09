namespace Anytype.NET.Constants;

/// <summary>
/// Provides version constants for the Anytype API.
/// </summary>
public static class AnytypeApiVersions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible member
    public const string V20250520 = "2025-05-20";
    public const string V20250422 = "2025-04-22";
    public const string V20250317 = "2025-03-17";
#pragma warning restore CS1591

    /// <summary>
    /// Returns the latest known API version.
    /// </summary>
    public static string GetLatest() => V20250520;
}
