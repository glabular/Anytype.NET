Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## Search Across Spaces

Executes a global search across all spaces.

```csharp
var searchRequest = new SearchRequest
{
    Query = "project management",
    Types = ["page", "task", "bookmark"],
    Sort = new SortOptions
    {
        Direction = "desc",
        PropertyKey = "last_modified_date"
    }
};

var searchResponse = await client.Search.AcrossSpacesAsync(searchRequest, offset: 0, limit: 100);

Console.WriteLine($"Total results: {searchResponse.Pagination.Total}");

foreach (var item in searchResponse.Data)
{
    Console.WriteLine($"- {item.Name} (ID: {item.Id}, Type: {item.Type?.Name ?? "Unknown"})");
}
```

### Parameters

- **request** (`SearchRequest`): The search criteria including query, types, and sort options
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of search results returned by the endpoint.
- pagination info: total count, offset, limit, and whether more results are available.

## Search in Space

Searches objects within a specific space.

```csharp
var searchRequest = new SearchRequest
{
    Query = "meeting notes",
    Types = ["page", "task"],
    Sort = new SortOptions
    {
        Direction = "asc",
        PropertyKey = "created_date"
    }
};

var searchResponse = await client.Search.InSpaceAsync("any-space-id", searchRequest, offset: 0, limit: 50);

Console.WriteLine($"Total results in space: {searchResponse.Pagination.Total}");

foreach (var item in searchResponse.Data)
{
    Console.WriteLine($"- {item.Name} (ID: {item.Id}, Archived: {item.Archived})");
}
```

### Parameters

- **spaceId** (string): ID of the space to search within
- **request** (`SearchRequest`): The search criteria including query, types, and sort options
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of search results returned by the endpoint.
- pagination info: total count, offset, limit, and whether more results are available.

## Search Request Structure

The `SearchRequest` object contains the following properties:

```csharp
public sealed class SearchRequest
{
    public string Query { get; set; }
    
    public string[] Types { get; set; }
    
    public SortOptions Sort { get; set; }
}
```

### Search Request Properties

- **Query** (string): The text to search within object names and content
- **Types** (string[]): The types of objects to include in results (e.g., "page", "task", "bookmark")
- **Sort** (`SortOptions`): The sorting options for the search results