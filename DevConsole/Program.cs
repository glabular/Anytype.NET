using Anytype.NET;
using Anytype.NET.Models;
using Microsoft.Extensions.Configuration;

namespace DevConsole;

internal class Program
{
    static async Task Main()
    {
        var apiKey = GetApiKeyFromConfig();
        var client = new AnytypeClient(apiKey);

        //
        // === Demo section: showcasing example API calls using AnytypeClient ===
        //


        // Get all spaces
        await GetAndPrintSpaces(client);


        // Create a new space
        var name = "AnySpace 3";
        var description = "This is a space created from the console application.";
        var space = await CreateSpaceAsync(client, name, description);

        Console.WriteLine("New space created:");
        Console.WriteLine($"{space.Name}");
        Console.WriteLine($"Description: {space.Description}");
        Console.WriteLine($"ID: {space.Id}");
    }

    /// <summary>
    /// Creates a new space with the given name and optional description.
    /// </summary>
    private static async Task<Space> CreateSpaceAsync(AnytypeClient client, string name, string? description = null)
    {
        var request = new CreateSpaceRequest
        {
            Name = name,
            Description = description ?? string.Empty
        };

        var newSpace = await client.CreateSpaceAsync(request);

        return newSpace;
    }

    /// <summary>
    /// Retrieves all available spaces and prints them in the console.
    /// </summary>
    private static async Task GetAndPrintSpaces(AnytypeClient client)
    {
        try
        {
            var spaces = await client.GetSpacesAsync();

            if (spaces.Count == 0)
            {
                Console.WriteLine("No spaces found.");
            }
            else if (spaces.Count == 1)
            {
                Console.WriteLine("1 space loaded:");
            }
            else
            {
                Console.WriteLine($"{spaces.Count} spaces loaded:");
            }

            foreach (var space in spaces)
            {
                Console.WriteLine($"{space.Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static string GetApiKeyFromConfig()
    {
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");

        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? string.Empty;

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .Build();

        return config["ApiKey"] ?? string.Empty;
    }
}
