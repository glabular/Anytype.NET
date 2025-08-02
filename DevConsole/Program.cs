using Anytype.NET;
using Microsoft.Extensions.Configuration;

namespace DevConsole;

internal class Program
{
    static async Task Main()
    {
        var apiKey = GetApiKeyFromConfig();

        try
        {
            var client = new AnytypeClient(apiKey);

            var spaces = await client.GetSpacesAsync();

            Console.WriteLine($"{spaces.Count} spaces loaded:");

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

    static string GetApiKeyFromConfig()
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
