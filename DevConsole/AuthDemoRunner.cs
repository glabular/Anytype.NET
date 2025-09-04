using Anytype.NET;
using Anytype.NET.Models.Responses;

namespace DevConsole;

public static class AuthDemoRunner
{
    public static async Task Run()
    {
        // Step 1: Request challenge
        Console.WriteLine("Requesting challenge from Anytype. Please, wait...");
        var challengeId = await AnytypeClient.Auth.CreateChallengeAsync("anytype_mcp");
        Console.WriteLine($"Challenge ID: {challengeId}");

        // Step 2: Enter code from Anytype Desktop
        Console.Write("Enter the 4-digit code shown in Anytype Desktop: ");
        var code = Console.ReadLine();

        // Step 3: Get API key
        var apiKey = await AnytypeClient.Auth.CreateApiKeyAsync(challengeId, code!);
        Console.WriteLine($"API Key obtained: {apiKey}");

        // Step 4: Initialize main client
        Console.WriteLine("Initializing Anytype.NET client with new API key...");
        var client = new AnytypeClient(apiKey);

        // Use the main client
        Console.WriteLine("\nTesting main client: retrieving spaces...");
        var response = await client.Spaces.ListAsync();
        Console.WriteLine($"Spaces retrieved: {response?.Spaces?.Count ?? 0}");
    }
}
