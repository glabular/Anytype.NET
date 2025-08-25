using Anytype.NET.Internal;
using Anytype.NET.Models;
using System.Diagnostics;
using Anytype.NET.Models.Requests;

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
        Assert.All(result.Spaces, space =>
        {
            Assert.False(string.IsNullOrWhiteSpace(space.Id)); // Ensure IDs are present
        });
    }

    [Fact]
    public async Task ListAsync_Fails_WhenApiKeyMissing()
    {
        var unauthClient = new SpacesClient("any_invalid_key");

        var ex = await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await unauthClient.ListAsync();
        });

        Assert.Contains("401", ex.Message);
    }

    [Fact]
    public async Task ListAsync_CompletesUnderOneSecond()
    {
        var sw = Stopwatch.StartNew();

        await _client.ListAsync();

        sw.Stop();
        Assert.True(sw.ElapsedMilliseconds < 1000, "API call took too long.");
    }

    [Fact]
    public async Task CreateAsync_CreatesSpaceSuccessfully()
    {
        // Arrange
        var name = "Test Space";
        var request = new CreateSpaceRequest()
        {
            Name = name,
            Description = "This is a test space created during unit testing.",
        };

        // Act
        var space = await _client.CreateAsync(request);

        // Assert
        Assert.NotNull(space);
        Assert.False(string.IsNullOrWhiteSpace(space.Id));
        Assert.Equal(name, space.Name);
    }

    [Fact]
    public async Task UpdateAsync_UpdatesSpaceSuccessfully()
    {
        // Arrange
        var space = await CreateTestSpace();
        const string updatedName = "Updated Space";
        var updateRequest = new UpdateSpaceRequest { Name = updatedName };

        // Act
        var updated = await _client.UpdateAsync(space.Id, updateRequest);

        // Assert
        Assert.NotNull(updated);
        Assert.Equal(space.Id, updated.Id);
        Assert.Equal(updatedName, updated.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsSpace_WhenIdIsValid()
    {
        // Arrange
        var space = await CreateTestSpace();

        // Act
        var result = await _client.GetByIdAsync(space.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(space.Id, result.Id);
        Assert.Equal(space.Name, result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsArgumentException_WhenIdIsNullOrWhitespace()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await _client.GetByIdAsync(null!);
        });

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await _client.GetByIdAsync("   ");
        });
    }

    private async Task<Space> CreateTestSpace(string name = "Test Space")
    {
        return await _client.CreateAsync(new CreateSpaceRequest() { Name = name });
    }
}
