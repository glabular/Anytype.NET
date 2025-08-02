namespace Anytype.NET.Models;

public class SpacesPagination
{
    public int Total { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }

    public bool HasMore { get; set; }
}
