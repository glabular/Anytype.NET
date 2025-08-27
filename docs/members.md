Before using any endpoint you should create a Anytype.NET client instance with you API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## List Members

Retrieves a paginated list of members in a specific space.

```csharp
var response = await client.Members.ListAsync("space-id", offset: 0, limit: 100);

Console.WriteLine($"Total members: {response.Pagination.Total}");

foreach (var member in response.Members)
{
    Console.WriteLine($"{member.Name} ({member.Id})");
}
```

### Parameters:

- **spaceId** (string): The ID of the space to list members for.  
- **offset** (int, default 0): Number of items to skip.
- **limit** (int, default 100, max 1000): Number of items to return.

### Returns

A response object containing:
- a list of members returned by the endpoint.
- pagination info: total count, offset, limit, and whether more members are available.

## Get a Member by ID

Retrieves a single member from a space.

```csharp
var member = await client.Members.GetByIdAsync("space-id", "member-id");

if (member != null)
{
    Console.WriteLine($"Member name: {member.Name}");
}
```

### Parameters:

- **spaceId** (string): The ID of the space containing the member.  
- **memberId** (string): The ID of the member to retrieve.

### Returns:

- `AnyMember` — the member object, or `null` if not found.
