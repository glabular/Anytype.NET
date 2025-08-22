using Anytype.NET.Internal;
using Anytype.NET.Models;

namespace Anytype.NET.Tests;

public class SpacesClientTests
{
    private readonly SpacesClient _client;

    public SpacesClientTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("ANYTYPE_API_TESTING_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("Set ANYTYPE_API_TESTING_KEY environment variable first.");
        }

        _client = new SpacesClient(apiKey);
    }

    [Fact]
    public async Task ListAsync_ReturnsSpaces()
    {
        var result = await _client.ListAsync();

        Assert.NotNull(result);           // Ensure API returned something
        Assert.NotNull(result.Spaces);    // Ensure Spaces property exists
        Assert.NotEmpty(result.Spaces);   // Ensure at least one space exists
    }
}
