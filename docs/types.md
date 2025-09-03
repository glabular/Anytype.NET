Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;
var client = new AnytypeClient("your-api-key");
```

---

## List Types

Gets a list of types from the given space.

```csharp
var types = await client.Types.ListAsync("any-space-id", offset: 0, limit: 100);

Console.WriteLine("Types retrieved:");

foreach (var type in types.Data)
{
    Console.WriteLine($"Name: {type.Name}");
    Console.WriteLine($"ID: {type.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space to list types from
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of types returned by the endpoint.
- pagination info: total count, offset, limit, and whether more types are available.

## Create a New Type

Creates a new type in the given space.

```csharp
var createTypeRequest = new CreateTypeRequest
{
    Icon = new EmojiIcon("📄"),
    Key = "some_user_defined_key",
    Layout = "basic",
    Name = "Page",
    PluralName = "Pages",
    Properties = new List<TypePropertyRequest>
    {
        new TypePropertyRequest
        {
            Format = "text",
            Key = "last_modified_date",
            Name = "Last modified date"
        }
    }
};

var createdType = await client.Types.CreateAsync("any-space-id", createTypeRequest);

Console.WriteLine("New type created:");
Console.WriteLine($"Name: {createdType.Name}");
Console.WriteLine($"ID: {createdType.Id}");
```

### Parameters

- **spaceId** (string): ID of the space where the type will be created
- **request** (CreateTypeRequest): Data required to create the type

### Returns

- the created type (```Type```).

## Get Type by ID

Retrieves a specific type by ID.

```csharp
var anyType = await client.Types.GetByIdAsync("any-space-id", "any-type-id");

Console.WriteLine("Type retrieved:");
Console.WriteLine($"Name: {anyType.Name}");
Console.WriteLine($"ID: {anyType.Id}");
```

### Parameters

- **spaceId** (string): ID of the space containing the type
- **typeId** (string): ID of the type to retrieve

### Returns

- ```Type``` — the type, or null if not found.

## Update Type

Updates an existing type.

```csharp
var updateTypeRequest = new UpdateTypeRequest
{
    Name = "Updated Task Type",
    Icon = new EmojiIcon("🔄"),
    Description = "An updated description for the task type"
};

var updatedType = await client.Types.UpdateAsync(
    "any-space-id",
    "any-type-id",
    updateTypeRequest);
```

### Parameters

- **spaceId** (string): ID of the space containing the type
- **typeId** (string): ID of the type to update
- **request** (UpdateTypeRequest): Data to update on the type

### Returns

- ``Type`` — the updated type.

## Delete Type

"Deletes" a type by marking it as archived.

```csharp
var deletedType = await client.Types.DeleteAsync("any-space-id", "any-type-id");
```

### Parameters

- **spaceId** (string): ID of the space containing the type
- **typeId** (string): ID of the type to delete

### Returns

- ```Type``` — the deleted (archived) type.
