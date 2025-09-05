Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## List Views

Gets a list of views defined for a specific list (collection or set) within a space.

```csharp
var response = await _anytypeClient.Lists.ListViewsAsync("any-space-id", "any-list-id", offset: 0, limit: 100);

Console.WriteLine($"{response.Pagination.Total} views retrieved:");

foreach (var view in response.Views)
{
    Console.WriteLine($"Name: {view.Name}");
    Console.WriteLine($"ID: {view.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space containing the list
- **listId** (string): ID of the list (collection or set) to get views for
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of views returned by the endpoint.
- pagination info: total count, offset, limit, and whether more views are available.

## List Objects in List

Gets the objects for a specific list and view. When a view ID is provided, objects are filtered and sorted according to the view's configuration.

```csharp
// Get objects with a specific view
var objectsWithView = await client.Lists.ListObjectsAsync("any-space-id", "any-list-id", "any-view-id", offset: 0, limit: 50);

// Get all objects in the list
var allObjects = await client.Lists.ListObjectsAsync("any-space-id", "any-list-id", viewId: null, offset: 0, limit: 50);

Console.WriteLine("Objects retrieved:");

foreach (var obj in objectsWithView.Objects)
{
    Console.WriteLine($"Name: {obj.Name}");
    Console.WriteLine($"ID: {obj.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space containing the list
- **listId** (string): ID of the list (collection or set) to get objects from
- **viewId** (string, optional): ID of the view for filtering and sorting; if null, all objects are returned
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of objects returned by the endpoint.
- pagination info: total count, offset, limit, and whether more objects are available.

## Add Objects to List

Adds one or more objects to a specific collection list by submitting a list of object IDs.

```csharp
var objectIds = new List<string> { "object-id-1", "object-id-2", "object-id-3" };
var result = await client.Lists.AddObjectsToListAsync("any-space-id", "any-list-id", objectIds);

Console.WriteLine($"Objects added: {result}");
```

### Parameters

- **spaceId** (string): ID of the space containing the list
- **listId** (string): ID of the list (collection) to add objects to
- **objectIds** (`List<string>`): The list of object IDs to add to the list

### Returns

- `string` — a confirmation message from the API.

## Remove Object from List

Removes a given object from the specified collection list.

```csharp
var result = await client.Lists.RemoveObjectFromListAsync("any-space-id", "any-list-id", "any-object-id");

Console.WriteLine($"Object removed: {result}");
```

### Parameters

- **spaceId** (string): ID of the space containing the list
- **listId** (string): ID of the list (collection) to remove the object from
- **objectId** (string): ID of the object to remove from the list

### Returns

- `string` — a confirmation message from the API.