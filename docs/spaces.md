Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## List Spaces

Gets a paginated list of all spaces that are accessible by the authenticated user.

```csharp
var response = await client.Spaces.ListAsync(offset: 0, limit: 100);

Console.WriteLine($"Total spaces: {response.Pagination.Total}");

foreach (var space in response.Spaces)
{
    Console.WriteLine($"{space.Name} ({space.Id})");
}
```

### Parameters:

- ```offset``` (int, default 0): Number of items to skip.
- ```limit``` (int, default 100, max 1000): Number of items to return.

### Returns

A response object containing:
- a list of spaces returned by the endpoint.
- pagination info: total count, offset, limit, and whether more spaces are available.

## Get a Space by ID

```csharp
var space = await client.Spaces.GetByIdAsync("any-space-id");

if (space != null)
{
    Console.WriteLine($"Space name: {space.Name}");
}
```

### Parameters:

- **spaceId** (string): The ID of the space.

### Returns:
- ```Space``` — the space object, or null if not found.

## Create a New Space

```csharp
var request = new CreateSpaceRequest
{
    Name = "C# Fandom",
    Description = "The local-first wiki"
};

var newSpace = await client.Spaces.CreateAsync(request);

Console.WriteLine($"Created space ID: {newSpace.Id}");

```

### Parameters:

- **request** (CreateSpaceRequest): Contains the space name (required) and description (optional).

### Returns:
- ```Space``` — the space object.

## Update an Existing Space

```csharp
var updateRequest = new UpdateSpaceRequest
{
    Name = "Updated Space Name",
    Description = "Updated description"
};

var updatedSpace = await client.Spaces.UpdateAsync("any-space-id", updateRequest);
Console.WriteLine($"Updated space: {updatedSpace.Name}");
```

### Parameters:

- **spaceId** (string): The ID of the space to update.
- **request** (UpdateSpaceRequest): Contains the new name and description.

### Returns:
- ```Space``` — the space object.