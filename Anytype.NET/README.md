# Anytype.NET
.NET client library for Anytype API.

It simplifies interaction with the API by taking care of HTTP calls, request/response handling, and JSON parsing — letting you focus on building features.
With it, you can easily create, retrieve, update, and manage Anytype objects directly in your applications.

# Getting Started

1. Install via NuGet:
```
dotnet add package Anytype.NET
```
2. Create a client
```
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```
> **TIP:** How to get an API key?
> 
> An API key is your access token — you create it once and then reuse it for all future sessions.
> 
> The simplest way to generate an API key is through the Anytype desktop client **(available in v0.46.6 or later)**:
>- Open the Anytype desktop app
>- Go to Settings
>- Navigate to the API Keys section
>- Click "Create new" and give it a meaningful name
>- Copy the generated API key
> 
> You can also generate an API key directly from code.  
> See [Auth Docs](https://github.com/glabular/Anytype.NET/blob/master/docs/auth.md) for details.

3. Usage example
```csharp
var response = await client.Spaces.ListAsync();

foreach (var space in response.Spaces)
{
    Console.WriteLine(space.Name);
    Console.WriteLine(space.Id);
}
```
The snippet above lists all available spaces and prints their names and IDs in the console.


## Supported Endpoints

| Category     | Endpoints |
|--------------|-----------|
| Auth       | Create Challenge • Create API Key |
| Search       | Search objects across all spaces • Search objects within a space |
| Spaces       | List • Create • Get • Update |
| Lists        | Add objects • Delete object • Get list views • Get objects |
| Members      | List • Get |
| Objects      | List • Create • Delete • Get • Update |
| Tags         | List • Create • Delete • Get • Update |
| Types        | List • Create • Delete • Get • Update |
| Templates    | List • Get |
| ⚠️ (Warning: experimental) Properties | List • Create • Delete • Get • Update |

## Compatibility
This client has been developed and tested with API version 2025-05-20 (latest).  
Other versions (2025-04-22, 2025-03-17) may work, but compatibility is not guaranteed.

---

## Contributing

Contributions, bug reports, and feature requests are welcome!  
If you'd like to contribute, feel free to open an issue or submit a pull request.

## Disclaimer

This project is not affiliated with or endorsed by Anytype. 
It's a personal project and my contribution to helping .NET developers use Anytype's API in a simple way.