using Anytype.NET;

namespace DevConsole;

internal class Program
{
    private const string EnvironmentVariableName = "ANYTYPE_API_TESTING_KEY";

    static async Task Main()
    {
        Console.WriteLine("Please ensure that Anytype Desktop is running for Anytype.NET to work and press ENTER.");
        Console.ReadLine();

        // --- Auth demo ---
        await AuthDemoRunner.Run();

        Console.WriteLine($"Make sure the environment variable {EnvironmentVariableName} is set and \npress ENTER to continue to the main Anytype demo...");
        Console.ReadLine();

        // --- Main Anytype demo ---
        var apiKey = Environment.GetEnvironmentVariable(EnvironmentVariableName);

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException($"Set {EnvironmentVariableName} environment variable first.");
        }

        var client = new AnytypeClient(apiKey);
        var demo = new DemoRunner(client);

        await demo.RunAsync();
    } 
}
