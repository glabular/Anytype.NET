Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;
var client = new AnytypeClient("your-api-key");
```

---

## List Templates

Gets a list of templates from the given type in the specified space.

```csharp
var response = await _anytypeClient.Templates.ListAsync("any-space-id", "any-type-id", offset: 0, limit: 100);

Console.WriteLine($"{response.Pagination.Total} templates retrieved:");

foreach (var template in response.Templates)
{
    Console.WriteLine($"Name: {template.Name}");
    Console.WriteLine($"ID: {template.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space containing the templates
- **typeId** (string): ID of the type to filter templates by
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of templates returned by the endpoint.
- pagination info: total count, offset, limit, and whether more templates are available.

## Get Template by ID

Retrieves a specific template by ID.

```csharp
var template = await client.Templates.GetByIdAsync("any-space-id", "any-type-id", "any-template-id");

Console.WriteLine("Template retrieved:");
Console.WriteLine($"Name: {template.Name}");
Console.WriteLine($"ID: {template.Id}");
```

### Parameters

- **spaceId** (string): ID of the space containing the template
- **typeId** (string): ID of the type that the template is associated with
- **templateId** (string): ID of the template to retrieve

### Returns

- ``Template`` — the template, or null if not found.