Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;

var client = new AnytypeClient("your-api-key");
```

---

## List Tags

Gets a list of tags from the given property in the specified space.

```csharp
var response = await client.Tags.ListAsync("any-space-id", "any-property-id");

Console.WriteLine($"{response.Pagination.Total} tags retrieved:");

foreach (var tag in response.Tags)
{
    Console.WriteLine($"Name: {tag.Name}");
    Console.WriteLine($"ID: {tag.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space containing the tags
- **propertyId** (string): ID of the property to list tags for

### Returns

A response object containing:
- a list of tags returned by the endpoint.
- pagination info: total count, offset, limit, and whether more tags are available.

## Create a New Tag

Creates a new tag for the given property in the specified space.

```csharp
var createTagRequest = new CreateTagRequest
{
    Name = "In progress",
    Color = "yellow"
};

var createdTag = await client.Tags.CreateAsync("any-space-id", "any-property-id", createTagRequest);

Console.WriteLine("New tag created:");
Console.WriteLine($"Name: {createdTag.Name}");
Console.WriteLine($"ID: {createdTag.Id}");
```

### Parameters

- **spaceId** (string): ID of the space where the tag will be created
- **propertyId** (string): ID of the property to create the tag for
- **request** (`CreateTagRequest`): Data required to create the tag

### Returns

- `Tag` — the created tag.

## Get Tag by ID

Retrieves a specific tag by ID.

```csharp
var tag = await client.Tags.GetByIdAsync(
	"any-space-id", 
	"any-property-id", 
	"any-tag-id");

Console.WriteLine("Tag retrieved:");
Console.WriteLine($"Name: {tag.Name}");
Console.WriteLine($"ID: {tag.Id}");
```

### Parameters

- **spaceId** (string): ID of the space containing the tag
- **propertyId** (string): ID of the property containing the tag
- **tagId** (string): ID of the tag to retrieve

### Returns

- `Tag` — the tag, or null if not found.

## Update Tag

Updates an existing tag.

```csharp
var updateTagRequest = new UpdateTagRequest
{
    Name = "Updated test in progress",
    Color = "yellow"
};

var updatedTag = await client.Tags.UpdateAsync(
    "any-space-id",
    "any-property-id",
    "any-tag-id",
    updateTagRequest);
```

### Parameters

- **spaceId** (string): ID of the space containing the tag
- **propertyId** (string): ID of the property containing the tag
- **tagId** (string): ID of the tag to update
- **request** (`UpdateTagRequest`): Data to update on the tag

### Returns

- `Tag` — the updated tag.

## Delete Tag

"Deletes" a tag by marking it as archived.

```csharp
var deletedTag = await client.Tags.DeleteAsync(
	"any-space-id", 
	"any-property-id", 
	"any-tag-id");
```

### Parameters

- **spaceId** (string): ID of the space containing the tag
- **propertyId** (string): ID of the property containing the tag
- **tagId** (string): ID of the tag to delete

### Returns

- `Tag` — the deleted (archived) tag.