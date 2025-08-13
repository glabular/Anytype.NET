using Anytype.NET;
using Anytype.NET.Internal;
using Anytype.NET.Models;
using Anytype.NET.Models.Enums;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
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


        //Create a new space
        var space = await CreateSpaceAsync(client);


        // Create a new object in the space
        var createdObject = await CreateObject(client);


        // Retrieve an object by its ID
        var requestedObject = await GetObjectById(client);


        // Update exsisting object
        var updatedObject = await UpdateObjectAsync(client);


        // Update space
        var updatedSpace = await UpdateSpaceAsync(client);


        // Get space by ID
        var requestedSpace = await GetSpaceByIdAsync(client);


        // Delete object
        var deletedObject = await DeleteObject(client);


        // List objects
        await ListObjectsAsync(client);


        // List members
        await ListMembersAsync(client);


        // Get member by ID
        var anytypeMember = await GetAnytypeMember(client);
    }

    private static async Task<AnyMember> GetAnytypeMember(AnytypeClient client)
    {
        // Replace with your actual values
        var member = await client.Members.GetByIdAsync(
            spaceId: string.Empty,
            memberId: string.Empty);

        Console.WriteLine($"The member with ID {member.Id} successfully retrieved.");

        return member;
    }

    private static async Task ListMembersAsync(AnytypeClient client)
    {
        // Replace with your actual space ID
        var spaceId = string.Empty;
        var offset = 0;
        var limit = 5;
        var hasMore = true;

        while (hasMore)
        {
            var response = await client.Members.ListMembersAsync(spaceId, offset, limit);

            Console.WriteLine($"Retrieved {response.Members.Count} members out of total {response.Pagination.Total} (offset {offset}).\n");

            foreach (var member in response.Members)
            {
                Console.WriteLine($"- {member.Name} (ID: {member.Id}, Role: {member.Role}, Status: {member.Status})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("More members are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping further loading of members.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("All possible members from the space have been loaded.");
            }
        }
    }

    private static async Task ListObjectsAsync(AnytypeClient client)
    {
        // Replace with your actual space ID
        var spaceId = string.Empty;
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await client.Objects.ListObjectsAsync(spaceId, offset, limit);

            Console.WriteLine($"Retrieved {response.Objects.Count} objects out of total {response.Pagination.Total} (offset {offset}).");

            foreach (var obj in response.Objects)
            {
                Console.WriteLine($"- {obj.Name} (ID: {obj.Id})");
            }

            Console.WriteLine();

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("More objects are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping further loading of objects.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("All available objects from the space have been loaded.");
            }
        }
    }

    private static async Task<AnyObject> DeleteObject(AnytypeClient client)
    {
        // Replace with your actual values
        var spaceId = string.Empty;
        var objectId = string.Empty; 

        var deletedObject = await client.Objects.DeleteObjectAsync(spaceId, objectId);

        Console.WriteLine($"The object with ID {objectId} in space {spaceId} has been successfully deleted.");

        return deletedObject;
    }

    private static async Task<Space> GetSpaceByIdAsync(AnytypeClient client)
    {
        var space = await client.Spaces.GetSpaceAsync(
            // Replace with your actual space ID
            string.Empty);

        Console.WriteLine($"The space with ID {space.Id} successfully retrieved.");

        return space;
    }

    private static async Task<Space?> UpdateSpaceAsync(AnytypeClient client)
    {
        var updateSpaceRequest = new UpdateSpaceRequest("Updated Space Name")
        {
            Description = "The local-first wiki"
        };

        var spaceId = string.Empty; // Replace with your actual space ID

        var space = await client.Spaces.UpdateSpaceAsync(spaceId, updateSpaceRequest);

        Console.WriteLine("The space has been successfully updated.");
        Console.WriteLine($"The new name: {space.Name}");

        return space;
    }

    private static async Task<AnyObject> UpdateObjectAsync(AnytypeClient client)
    {
        var updatedObject = await client.Objects.UpdateObjectAsync(
            // Replace with your actual values
            spaceId: string.Empty,
            objectId: string.Empty,
            new UpdateObjectRequest
            {
                Name = "New name",
                Icon = null,
                Properties =
                [
                    new
                    {
                        key = PropertyKey.Done,
                        checkbox = false
                    },
                    new 
                    {
                        key = PropertyKey.Description,
                        text = "This is an updated description for the object."
                    }
                ]
            });

        Console.WriteLine("Object has been successfully updated.");

        return updatedObject;
    }

    private static async Task<AnyObject> GetObjectById(AnytypeClient client)
    {
        var request = new ObjectRequest(
             // Replace with your actual values
            spaceId: string.Empty,
            objectId: string.Empty);

        var anyObject = await client.Objects.GetObjectAsync(request);
        Console.WriteLine("Object retrieved:");
        Console.WriteLine($"Name: {anyObject.Name}");
        Console.WriteLine($"ID: {anyObject.Id}");

        return anyObject;
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

        var createdObject = await client.Objects.CreateObjectAsync(spaceId, createObjectRequest);

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

        var newSpace = await client.Spaces.CreateSpaceAsync(request);

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
        var spaces = await client.Spaces.GetSpacesAsync();

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
