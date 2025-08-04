using Anytype.NET;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Microsoft.Extensions.Configuration;

namespace DevConsole;

internal class Program
{
    static async Task Main()
    {
        var apiKey = GetApiKeyFromConfig();
        var client = new AnytypeClient(apiKey);


        //
        // === Demo section: showcasing example API calls using Anytype.NET ===
        //


        // Get all spaces
        await GetSpacesAsync(client);


        // Create a new space        
        var space = await CreateSpaceAsync(client);


        // Create a new object in the space
        var createdObject = await CreateObject(client);
    }

    /// <summary>
    /// Creates a new page object in a specified space using the Anytype.NET client.
    /// </summary>
    private static async Task<AnyObject> CreateObject(AnytypeClient client)
    {
        // Replace with your actual space ID
        var spaceId = string.Empty;

        var createObjectRequest = new CreateObjectRequest
        {
            // Set the title of the page
            Name = "Antares",

            // Set the emoji icon for the page
            Icon = new Icon
            {
                Emoji = "🌟",
                Format = "emoji"
            },

            // The body supports Markdown formatting
            Body = "## Introduction\n\n" +
               "Antares is the brightest star in the constellation **Scorpius**.\n\n" +
               "- It is a **red supergiant**, nearing the end of its life.\n" +
               "- Antares is located approximately **550 light-years** from Earth.\n" +
               "- Its name means *'rival of Mars'* due to its reddish appearance.\n\n" +
               "### Fun Fact\n\n" +
               "Antares is so large that if it replaced the Sun, it would engulf the orbits of Mercury, Venus, Earth, and Mars.\n\n",

            // The type of the object being created
            TypeKey = "page",

            // Optional metadata properties
            Properties = new List<Property>
            {
                // A short description
                PropertyFactory.Description("An introductory overview of Antares."),

                // Mark the object as done
                PropertyFactory.Done(true)
            }
        };

        var createdObject = await client.CreateObjectAsync(spaceId, createObjectRequest);

        Console.WriteLine("New object created:");
        Console.WriteLine($"Name: {createdObject.Name}");
        Console.WriteLine($"ID: {createdObject.Id}");

        return createdObject;
    }

    /// <summary>
    /// Creates a new space in Anytype via the Anytype.NET client with a predefined name and description.
    /// Prints the details of the created space to the console.
    /// </summary>
    private static async Task<Space> CreateSpaceAsync(AnytypeClient client)
    {
        var name = "C# fandom";
        var description = "This is a space created using Anytype.NET.";

        var request = new CreateSpaceRequest(name)
        {
            Description = description
        };

        var newSpace = await client.CreateSpaceAsync(request);

        Console.WriteLine("New space created:");
        Console.WriteLine($"{newSpace.Name}");
        Console.WriteLine($"Description: {newSpace.Description}");
        Console.WriteLine($"ID: {newSpace.Id}");

        return newSpace;
    }

    /// <summary>
    /// Retrieves all available spaces from the Anytype API using the Anytype.NET client
    /// and prints their details to the console.
    /// </summary>
    private static async Task GetSpacesAsync(AnytypeClient client)
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
            Console.WriteLine($"{space.Id}");
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
