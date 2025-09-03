# Anytype API for .NET

**Anytype\.NET** is an unofficial .NET client library for accessing the Anytype API. 

It simplifies interaction with the API by taking care of HTTP calls, request/response handling, and JSON parsing — letting you focus on building features.
With it, you can easily create, retrieve, update, and manage Anytype objects directly in your applications.

# Getting Started

1. Install via NuGet:
```
dotnet add package Anytype.NET
```
2. Create a client
```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```
> [!TIP]
> **How to get an API key?**
>
> The simplest way to generate an API key is through the Anytype desktop client (available in v0.46.6 or later):
>- Open the Anytype desktop app
>- Go to Settings
>- Navigate to the API Keys section
>- Click "Create new" and give it a meaningful name
>- Copy the generated API key
> 
> You can also generate an API key directly from code.  
> See [Auth Docs](docs/auth.md) for details.

3. Usage example
```csharp
var name = "C# fandom";
var description = "This is a space created using Anytype.NET";

var request = new CreateSpaceRequest(name)
{
    Description = description
};

var newSpace = await client.Spaces.CreateAsync(request);

Console.WriteLine("New space created:");
Console.WriteLine(newSpace.Name);
Console.WriteLine($"Description: {newSpace.Description}");
Console.WriteLine($"ID: {newSpace.Id}");
```
The snippet above creates a new space and prints its name, description, and ID in the console.


## Supported Endpoints

| Category     | Endpoints |
|--------------|-----------|
| [Auth](/docs/auth.md)       | Create Challenge • Create API Key |
| [Search](/docs/search.md)       | Search objects across all spaces • Search objects within a space |
| [Spaces](/docs/spaces.md)       | List • Create • Get • Update |
| [Lists](/docs/lists.md)         | Add objects • Delete object • Get list views • Get objects |
| [Members](/docs/members.md)     | List • Get |
| [Objects](/docs/objects.md)     | List • Create • Delete • Get • Update |
| [Tags](/docs/tags.md)           | List • Create • Delete • Get • Update |
| [Types](/docs/types.md)         | List • Create • Delete • Get • Update |
| [Templates](/docs/templates.md) | List • Get |
| ⚠️ [Properties](/docs/properties.md) | List • Create • Delete • Get • Update |

###### Click a category to see detailed documentation.

## Compatibility
This client has been developed and tested with API version 2025-05-20 (latest).  
Other versions (2025-04-22, 2025-03-17) may work, but compatibility is not guaranteed.

---

> [!IMPORTANT]
> The Anytype desktop app must be running for the API to function.

## Contributing

Contributions, bug reports, and feature requests are welcome!  
If you'd like to contribute, feel free to open an issue or submit a pull request.

## Disclaimer

This project is not affiliated with or endorsed by Anytype. 
It's a personal project and my contribution to helping .NET developers use Anytype's API in a simple way.

## License

This project is licensed under the [MIT License](./LICENSE).