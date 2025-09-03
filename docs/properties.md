Before using any endpoint you should create a Anytype.NET client instance with your API key provided.

```csharp
using Anytype.NET;
var client = new AnytypeClient("your-api-key");
```

---

> ⚠️ **Warning**: Properties are experimental and may change in the next update.

---

## List Properties

Gets a list of properties from the given space.

```csharp
var properties = await client.Properties.ListAsync("any-space-id", offset: 0, limit: 100);

Console.WriteLine("Properties retrieved:");

foreach (var property in properties.Data)
{
    Console.WriteLine($"Name: {property.Name}");
    Console.WriteLine($"ID: {property.Id}");
}
```

### Parameters

- **spaceId** (string): ID of the space to list properties from
- **offset** (int, optional): The number of items to skip before collecting the result set. Default is 0
- **limit** (int, optional): The number of items to return. Max 1000. Default is 100

### Returns

A response object containing:
- a list of properties returned by the endpoint.
- pagination info: total count, offset, limit, and whether more properties are available.

## Create a New Property

Creates a new property in the given space.

```csharp
var createPropertyRequest = new CreatePropertyRequest
{
    Format = "text",
    Key = "some_user_defined_property_key",
    Name = "Testing date"
};

var createdProperty = await client.Properties.CreateAsync("any-space-id", createPropertyRequest);

Console.WriteLine("New property created:");
Console.WriteLine($"Name: {createdProperty.Name}");
Console.WriteLine($"ID: {createdProperty.Id}");
```

### Parameters

- **spaceId** (string): ID of the space where the property will be created
- **request** (`CreatePropertyRequest`): Data required to create the property

### Returns

- `TypeProperty` — the created property.

## Get Property by ID

Retrieves a specific property by ID.

```csharp
var property = await client.Properties.GetByIdAsync("any-space-id", "any-property-id");

Console.WriteLine("Property retrieved:");
Console.WriteLine($"Name: {property.Name}");
Console.WriteLine($"ID: {property.Id}");
```

### Parameters

- **spaceId** (string): ID of the space containing the property
- **propertyId** (string): ID of the property to retrieve

### Returns

- `TypeProperty` — the property, or null if not found.

## Update Property

Updates an existing property.

```csharp
var oldProperty = await client.Properties.GetByIdAsync(SpaceId, PropertyId);

var updateRequest = new UpdatePropertyRequest
{
    Key = "property_key",
    Name = "Updated Last Modified Date"
};

var updatedProperty = await client.Properties.UpdateAsync(SpaceId, PropertyId, updateRequest);

Console.WriteLine($"Old property - ID: {oldProperty.Id}, Key: {oldProperty.Key}, Name: {oldProperty.Name}.");
Console.WriteLine($"Updated property - ID: {updatedProperty.Id}, Key: {updatedProperty.Key}, Name: {updatedProperty.Name}.");

```

### Parameters

- **spaceId** (string): ID of the space containing the property
- **propertyId** (string): ID of the property to update
- **request** (`UpdatePropertyRequest`): Data to update on the property

### Returns

- `TypeProperty` — the updated property.

## Delete Property

"Deletes" a property by marking it as archived.

```csharp
var deletedProperty = await client.Properties.DeleteAsync("any-space-id", "any-property-id");
```

### Parameters

- **spaceId** (string): ID of the space containing the property
- **propertyId** (string): ID of the property to delete

### Returns

- `TypeProperty` — the deleted (archived) property.