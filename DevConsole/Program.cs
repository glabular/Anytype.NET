using Anytype.NET;

namespace DevConsole;

internal class Program
{
    private const string ApiKey = "";

    static async Task Main()
    {
        try
        {
            var client = new AnytypeClient(ApiKey);

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
}
