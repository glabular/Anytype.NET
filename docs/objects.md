Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## Create a New Object

Creates a new object in the given space.  

```csharp
var createObjectRequest = new CreateObjectRequest
{
    Name = "Any name",
    Icon = new EmojiIcon("🌟"),
    Body = "Any text goes here. Markdown supported",
    TypeKey = "page",	
    Properties =
    [
        new
        {
            key = "done",
            checkbox = false
        },
        new
        {
            key = "description",
            text = "This is the description for the object."
        }
    ]
};

var createdObject = await client.Objects.CreateAsync("any-space-id", createObjectRequest);

Console.WriteLine("New object created:");
Console.WriteLine($"Name: {createdObject.Name}");
Console.WriteLine($"ID: {createdObject.Id}");
```

### Parameters
- **spaceId** (string): ID of the space where the object will be created  
- **request** (createObjectRequest): Data required to create the object

### Returns
- the created ```Object```.

## Get Object by ID

Retrieves a specific object by ID.  

```csharp
var anyObject = await client.Objects.GetByIdAsync("any-space-id", "any-object-id");

Console.WriteLine("Object retrieved:");
Console.WriteLine($"Name: {anyObject.Name}");
Console.WriteLine($"ID: {anyObject.Id}");
```

### Parameters
- **spaceId** (string): ID of the space containing the object  
- **objectId** (string): ID of the object to retrieve  
- **format** (string, optional): Format of the object body (default `"md"`)  

### Returns
- ```Object``` — the object, or null if not found.

## Update Object

Updates an existing object.  

```csharp
var updateObjectRequest = new UpdateObjectRequest
{
    Name = "New name",
    Icon = null,
    Properties =
    [
        new
        {
            key = "done",
            checkbox = true
        },
        new
        {
            key = "description",
            text = "This is an updated description for the object."
        }
    ]
};

var updatedObject = await client.Objects.UpdateAsync(
    "any-space-id",
    "any-object-id",
    updateObjectRequest);
```

### Parameters
- **spaceId** (string): ID of the space containing the object  
- **objectId** (string): ID of the object to update  
- **request** (updateObjectRequest): Data to update on the object  

### Returns
- the updated ```Object```.

## Delete Object

"Deletes" an object by marking it as archived.

```csharp
var deletedObject = await client.Objects.DeleteAsync("any-space-id", "any-object-id");
```

### Parameters
- **spaceId** (string): ID of the space containing the object  
- **objectId** (string): ID of the object to delete  

### Returns
- the deleted (archived) ```Object```.

## List Objects

Gets a list of objects from the given space.

```csharp
var response = await _anytypeClient.Objects.ListAsync("any-space-id", offset: 0, limit: 100);

Console.WriteLine($"{response.Pagination.Total} objects retrieved:");

foreach (var obj in response.Objects)
{
    Console.WriteLine($"Name: {obj.Name}");
    Console.WriteLine($"ID: {obj.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space to list objects from
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of objects returned by the endpoint.
- pagination info: total count, offset, limit, and whether more objects are available.
