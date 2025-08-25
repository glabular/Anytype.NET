using Anytype.NET;

namespace DevConsole;

internal class Program
{
    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("ANYTYPE_API_TESTING_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("Set ANYTYPE_API_TESTING_KEY environment variable first.");
        }

        var client = new AnytypeClient(apiKey);
        var demo = new DemoRunner(client);

        await demo.RunAsync();
    } 
}
