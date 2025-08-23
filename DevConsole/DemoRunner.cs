using Anytype.NET;
using Anytype.NET.Models;
using Anytype.NET.Models.Enums;
using Anytype.NET.Models.Requests;
using System.Collections.Generic;

namespace DevConsole;

public class DemoRunner
{
    private readonly AnytypeClient _client;

    private const string SpaceId = "";
    private const string ObjectId = "";
    private const string MemberId = "";
    private const string TypeId = "";
    private const string TemplateId = "";
    private const string PropertyId = "";
    private const string TagId = "";
    private const string ListId = "";
    private const string ViewId = "";

    public DemoRunner(AnytypeClient client)
    {
        _client = client;
    }

    public async Task RunAsync()
    {
        //
        // === Demo: showcasing example API calls using Anytype.NET ===
        //
        // Select which demo sections to run by uncommenting
        // the desired method calls below.  
        // Be sure to set any required ID constants in advance.
        //

        //await DemoSpacesAsync();
        //await DemoObjectsAsync();
        //await DemoTypesAsync();
        //await DemoMembersAsync();
        //await DemoTemplatesAsync();
        //await DemoPropertiesAsync();
        //await DemoTagsAsync();
        //await DemoSearchAsync();
        //await DemoListsAsync();
    }   

    private async Task DemoSpacesAsync()
    {
        await GetSpacesAsync();
        var space = await CreateSpaceAsync();
        var updatedSpace = await UpdateSpaceAsync();
        var requestedSpace = await GetSpaceByIdAsync();
    }

    private async Task DemoObjectsAsync()
    {
        var createdObject = await CreateObjectAsync();
        var requestedObject = await GetObjectByIdAsync();
        var updatedObject = await UpdateObjectAsync();
        var deletedObject = await DeleteObjectAsync();
        await ListObjectsAsync();
    }

    private async Task DemoTypesAsync()
    {
        var newType = await CreateTypeAsync();
        var type = await GetTypeByIdAsync();
        var updatedType = await UpdateTypeByIdAsync();
        var deletedType = await DeleteTypeAsync();
        await ListTypesAsync();
    }

    private async Task DemoTemplatesAsync()
    {
        await ListTemplatesAsync();
        var template = await GetTemplateByIdAsync();
    }

    private async Task DemoPropertiesAsync()
    {
        await ListPropertiesAsync();
        var newProperty = await CreatePropertyAsync();
        var property = await GetPropertyByIdAsync();
        var deletedProperty = await DeletePropertyAsync();
        var updatedProperty = await UpdatePropertyAsync();
    }

    private async Task DemoTagsAsync()
    {
        await ListTagsAsync();
        var newTag = await CreateTagAsync();
        var tag = await GetTagByIdAsync();
        var updatedTag = await UpdateTagAsync();
        var deletedTag = await DeleteTagAsync();
    }

    private async Task DemoSearchAsync()
    {
        await SearchObjectsAcrossSpacesAsync();
        await SearchObjectsWithinSpaceAsync();
    }

    private async Task DemoListsAsync()
    {
        await GetListViewsAsync();
        await GetListObjectsAsync();
        await AddObjectsToListAsync();
        await DeleteObjectFromListAsync();
    }

    private async Task DeleteObjectFromListAsync()
    {
        var result = await _client.Lists.RemoveObjectFromListAsync(SpaceId, ListId, ObjectId);
        Console.WriteLine($"Remove object response: {result}");
    }

    private async Task AddObjectsToListAsync()
    {
        var objectIds = new List<string>
        {
            // Provide your IDs here:

        };

        var result = await _client.Lists.AddObjectsToListAsync(SpaceId, ListId, objectIds);
        Console.WriteLine($"Add objects response: {result}");
    }

    private async Task GetListObjectsAsync()
    {
        var objectsResponse = await _client.Lists.ListObjectsAsync(SpaceId, ListId, ViewId, offset: 0, limit: 100);

        Console.WriteLine($"Total objects in view {ViewId}: {objectsResponse.Pagination.Total}");

        foreach (var obj in objectsResponse.Objects)
        {
            Console.WriteLine($"- Object ID: {obj.Id}");
            Console.WriteLine($"  Name: {obj.Name ?? "(no name)"}");
            Console.WriteLine($"  Object Type: {obj.Object}");
            Console.WriteLine($"  Space ID: {obj.SpaceId}");
            Console.WriteLine($"  Archived: {(obj.Archived ? "Yes" : "No")}");
        }

        Console.WriteLine();
    }

    private async Task GetListViewsAsync()
    {
        var response = await _client.Lists.ListViewsAsync(SpaceId, ListId, offset: 0, limit: 100);

        Console.WriteLine($"Total views for list {ListId}: {response.Pagination.Total}");

        foreach (var view in response.Data)
        {
            Console.WriteLine($"- View ID: {view.Id}, Name: {view.Name}, Layout: {view.Layout}, " +
                              $"Filters: {view.Filters?.Count ?? 0}, Sorts: {view.Sorts?.Count ?? 0}");
        }

        Console.WriteLine();
    }

    private async Task SearchObjectsWithinSpaceAsync()
    {
        var searchRequest = new SearchRequest
        {
            Query = "any",
            Types = ["page", "task", "bookmark"],
            Sort = new SortOptions
            {
                Direction = "desc",
                PropertyKey = "last_modified_date"
            }
        };

        var searchResponse = await _client.Search.InSpaceAsync(SpaceId, searchRequest, offset: 0, limit: 100);

        Console.WriteLine($"Total results in space {SpaceId}: {searchResponse.Pagination.Total}");

        foreach (var item in searchResponse.Data)
        {
            Console.WriteLine($"- {item.Name} (ID: {item.Id}, Type: {item.Type?.Name ?? "Unknown"}, Archived: {item.Archived})");
        }

        Console.WriteLine();
    }

    private async Task SearchObjectsAcrossSpacesAsync()
    {
        var searchRequest = new SearchRequest
        {
            Query = "test",
            Types = ["page", "task", "bookmark"],
            Sort = new SortOptions
            {
                Direction = "asc",
                PropertyKey = "last_modified_date"
            }
        };

        var searchResponse = await _client.Search.AcrossSpacesAsync(searchRequest, offset: 0, limit: 100);

        Console.WriteLine($"Total results: {searchResponse.Pagination.Total}");

        foreach (var item in searchResponse.Data)
        {
            Console.WriteLine($"- {item.Name} (ID: {item.Id}, Type: {item.Type?.Name ?? "Unknown"}, Archived: {item.Archived})");
        }

        Console.WriteLine();
    }

    private async Task<Tag> DeleteTagAsync()
    {
        var deletedTag = await _client.Tags.DeleteAsync(SpaceId, PropertyId, TagId);
        Console.WriteLine($"Deleted (archived) tag with ID {deletedTag.Id}, Key: {deletedTag.Key}, Name: {deletedTag.Name}.");
        
        return deletedTag;
    }

    private async Task<Tag> UpdateTagAsync()
    {
        var oldTag = await _client.Tags.GetByIdAsync(SpaceId, PropertyId, TagId);

        var updateRequest = new UpdateTagRequest
        {
            Name = "Updated test in progress",
            Color = "yellow"
        };

        var updatedTag = await _client.Tags.UpdateAsync(SpaceId, PropertyId, TagId, updateRequest);
        
        Console.WriteLine($"Old tag - ID: {oldTag.Id}, Key: {oldTag.Key}, Name: {oldTag.Name}, Color: {oldTag.Color}.");
        Console.WriteLine($"Updated tag - ID: {updatedTag.Id}, Key: {updatedTag.Key}, Name: {updatedTag.Name}, Color: {updatedTag.Color}.");

        return updatedTag;
    }

    private async Task<Tag> GetTagByIdAsync()
    {
        var tag = await _client.Tags.GetByIdAsync(SpaceId, PropertyId, TagId);
        Console.WriteLine($"Retrieved tag with ID {tag.Id}, Key: {tag.Key}, Name: {tag.Name}, Color: {tag.Color}.");
        
        return tag;
    }

    private async Task<Tag> CreateTagAsync()
    {
        var createTagRequest = new CreateTagRequest
        {
            Name = "In progress",
            Color = "yellow"
        };

        var newTag = await _client.Tags.CreateAsync(SpaceId, PropertyId, createTagRequest);
        Console.WriteLine($"Created new tag with ID {newTag.Id}, Key: {newTag.Key}, Name: {newTag.Name}, Color: {newTag.Color}.");

        return newTag;
    }

    private async Task ListTagsAsync()
    {
        bool hasMore = true;

        while (hasMore)
        {
            var response = await _client.Tags.ListAsync(SpaceId, PropertyId);
            Console.WriteLine($"Retrieved {response.Tags.Count} tags out of total {response.Pagination.Total}.\n");

            foreach (var tag in response.Tags)
            {
                Console.WriteLine($"- {tag.Name} (ID: {tag.Id}, Color: {tag.Color})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("\nMore tags are available. Do you want to load more? (y/n): ");
                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nStopping further loading of tags.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nAll available tags have been loaded.");
            }
        }
    }

    private async Task<TypeProperty> UpdatePropertyAsync()
    {
        var oldProperty = await _client.Properties.GetByIdAsync(SpaceId, PropertyId);

        var updateRequest = new UpdatePropertyRequest
        {
            Key = "property_key",
            Name = "Updated Last Modified Date"
        };

        var updatedProperty = await _client.Properties.UpdateAsync(SpaceId, PropertyId, updateRequest);

        Console.WriteLine($"Old property - ID: {oldProperty.Id}, Key: {oldProperty.Key}, Name: {oldProperty.Name}.");
        Console.WriteLine($"Updated property - ID: {updatedProperty.Id}, Key: {updatedProperty.Key}, Name: {updatedProperty.Name}.");

        return updatedProperty;
    }

    private async Task<TypeProperty> DeletePropertyAsync()
    {
        var deletedProperty = await _client.Properties.DeleteAsync(SpaceId, PropertyId);
        Console.WriteLine("Deleted (archived) property with:");
        Console.WriteLine($"ID: {deletedProperty.Id}, Key: {deletedProperty.Key}, Name: {deletedProperty.Name}.");

        return deletedProperty;
    }

    private async Task<TypeProperty> GetPropertyByIdAsync()
    {
        var property = await _client.Properties.GetByIdAsync(SpaceId, PropertyId);

        Console.WriteLine($"Retrieved property with ID {property.Id}, Name: {property.Name}, Key: {property.Key}.");

        return property;
    }

    private async Task<TypeProperty> CreatePropertyAsync()
    {
        var createPropertyRequest = new CreatePropertyRequest
        {
            Format = "text",
            Key = "some_user_defined_property_key",
            Name = "Testing date"
        };

        var createdProperty = await _client.Properties.CreateAsync(SpaceId, createPropertyRequest);
        Console.WriteLine($"Created new property with ID {createdProperty.Id}, Key: {createdProperty.Key}, Name: {createdProperty.Name}.");
        
        return createdProperty;
    }

    private async Task ListPropertiesAsync()
    {
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Properties.ListAsync(SpaceId, offset, limit);
            Console.WriteLine($"Retrieved {response.Properties.Count} properties out of total {response.Pagination.Total} (offset {offset}).\n");

            foreach (var property in response.Properties)
            {
                Console.WriteLine($"- {property.Name} (ID: {property.Id}, Format: {property.Format})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("\nMore properties are available. Do you want to load more? (y/n): ");
                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nStopping further loading of properties.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nAll available properties from the space have been loaded.");
            }
        }
    }

    private async Task<Template> GetTemplateByIdAsync()
    {
        var template = await _client.Templates.GetByIdAsync(SpaceId, TypeId, TemplateId);
        Console.WriteLine($"Retrieved template with ID {template.Id}, Name: {template.Name}, Archived: {template.Archived}.");
        
        return template;
    }

    private async Task ListTemplatesAsync()
    {
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Templates.ListAsync(SpaceId, TypeId, offset, limit);

            Console.WriteLine($"Retrieved {response.Data.Count} templates out of total {response.Pagination.Total} (offset {offset}).\n");
            
            foreach (var template in response.Data)
            {
                Console.WriteLine($"- {template.Name} (ID: {template.Id}, Archived: {template.Archived})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("\nMore templates are available. Do you want to load more? (y/n): ");
                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);
                if (keyChar == 'y')
                {
                    offset += limit;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nStopping further loading of templates.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nAll available templates from the type have been loaded.");
            }
        }
    }

    private async Task<AnyType> UpdateTypeByIdAsync()
    {
        var updateRequest = new UpdateTypeRequest
        {
            Icon = new EmojiIcon("📄"),
            Key = "your_key",
            Layout = "basic",
            Name = "Updated Page",
            PluralName = "Updated Pages",
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

        var updatedType = await _client.Types.UpdateAsync(SpaceId, TypeId, updateRequest);
        Console.WriteLine($"Updated type with ID {updatedType.Id} and name {updatedType.Name}.");

        return updatedType;
    }

    private async Task<AnyType> GetTypeByIdAsync()
    {
        var type = await _client.Types.GetByIdAsync(SpaceId, TypeId);

        Console.WriteLine($"Retrieved type with ID {type.Id}, Name: {type.Name}, Key: {type.Key}, Archived: {type.Archived}.");
        
        return type;
    }

    private async Task DemoMembersAsync()
    {
        await ListMembersAsync();
        var anytypeMember = await GetAnytypeMemberAsync();
    }

    private async Task<AnyType> DeleteTypeAsync()
    {
        var deletedType = await _client.Types.DeleteAsync(SpaceId, TypeId);

        Console.WriteLine($"The type with ID {deletedType.Id} in space {SpaceId} has been successfully deleted.");

        return deletedType;
    }

    private async Task<AnyType> CreateTypeAsync()
    {
        var createRequest = new CreateTypeRequest
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

        var newType = await _client.Types.CreateAsync(SpaceId, createRequest);

        Console.WriteLine($"Created new type with ID {newType.Id} and name {newType.Name}.");

        return newType;
    }

    private async Task ListTypesAsync()
    {
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Types.ListAsync(SpaceId, offset, limit);

            Console.WriteLine($"Retrieved {response.Data.Count} types out of total {response.Pagination.Total} (offset {offset}).\n");

            foreach (var type in response.Data)
            {
                Console.WriteLine($"- {type.Name} (ID: {type.Id}, Key: {type.Key}, Archived: {type.Archived})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("\nMore types are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nStopping further loading of types.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nAll available types from the space have been loaded.");
            }
        }
    }

    private async Task<AnyMember> GetAnytypeMemberAsync()
    {
        var member = await _client.Members.GetByIdAsync(
            SpaceId,
            MemberId);

        Console.WriteLine($"The member with ID {member.Id} successfully retrieved.");

        return member;
    }

    private async Task ListMembersAsync()
    {
        var offset = 0;
        var limit = 5;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Members.ListAsync(SpaceId, offset, limit);

            Console.WriteLine($"Retrieved {response.Members.Count} members out of total {response.Pagination.Total} (offset {offset}).\n");

            foreach (var member in response.Members)
            {
                Console.WriteLine($"- {member.Name} (ID: {member.Id}, Role: {member.Role}, Status: {member.Status})");
            }

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("More members are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping further loading of members.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("All possible members from the space have been loaded.");
            }
        }
    }

    private async Task ListObjectsAsync()
    {        
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Objects.ListAsync(SpaceId, offset, limit);

            Console.WriteLine($"Retrieved {response.Objects.Count} objects out of total {response.Pagination.Total} (offset {offset}).");

            foreach (var obj in response.Objects)
            {
                Console.WriteLine($"- {obj.Name} (ID: {obj.Id})");
            }

            Console.WriteLine();

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("More objects are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping further loading of objects.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("All available objects from the space have been loaded.");
            }
        }
    }

    private async Task<AnyObject> DeleteObjectAsync()
    {
        var deletedObject = await _client.Objects.DeleteAsync(SpaceId, ObjectId);

        Console.WriteLine($"The object with ID {ObjectId} in space {SpaceId} has been successfully deleted.");

        return deletedObject;
    }

    private async Task<Space> GetSpaceByIdAsync()
    {
        var space = await _client.Spaces.GetByIdAsync(SpaceId);

        Console.WriteLine($"The space with ID {space.Id} successfully retrieved.");

        return space;
    }

    private async Task<Space?> UpdateSpaceAsync()
    {
        var updateSpaceRequest = new UpdateSpaceRequest("Updated Space Name")
        {
            Description = "The local-first wiki"
        };

        var space = await _client.Spaces.UpdateAsync(SpaceId, updateSpaceRequest);

        Console.WriteLine("The space has been successfully updated.");
        Console.WriteLine($"The new name: {space.Name}");

        return space;
    }

    private async Task<AnyObject> UpdateObjectAsync()
    {
        var updateObjectRequest = new UpdateObjectRequest
        {
            Name = "New name",
            Icon = null,
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
                    text = "This is an updated description for the object."
                }
            ]
        };

        var updatedObject = await _client.Objects.UpdateAsync(
            SpaceId,
            ObjectId,
            updateObjectRequest);

        Console.WriteLine("Object has been successfully updated.");

        return updatedObject;
    }

    private async Task<AnyObject> GetObjectByIdAsync()
    {
        var anyObject = await _client.Objects.GetByIdAsync(SpaceId, ObjectId);

        Console.WriteLine("Object retrieved:");
        Console.WriteLine($"Name: {anyObject.Name}");
        Console.WriteLine($"ID: {anyObject.Id}");

        return anyObject;
    }

    private async Task<AnyObject> CreateObjectAsync()
    {
        var createObjectRequest = new CreateObjectRequest
        {
            // Set the title of the page
            Name = "listingtesting",

            // Set the emoji icon for the page
            Icon = new EmojiIcon("🌟"),

            // The body supports Markdown formatting
            Body = "## Introduction\n\n" +
               "Antares is the brightest star in the constellation **Scorpius**.\n\n" +
               "- It is a **red supergiant**, nearing the end of its life.\n" +
               "- Antares is located approximately **550 light-years** from Earth.\n" +
               "- Its name means *'rival of Mars'* due to its reddish appearance.\n\n" +
               "### Fun Fact\n\n" +
               "Antares is so large that if it replaced the Sun, it would engulf the orbits of Mercury, Venus, Earth, and Mars.\n\n",

            // The type of the object being created
            TypeKey = "page",

            // Optional metadata properties
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
                    text = "This is an updated description for the object."
                }
            ]
        };

        var createdObject = await _client.Objects.CreateAsync(SpaceId, createObjectRequest);

        Console.WriteLine("New object created:");
        Console.WriteLine($"Name: {createdObject.Name}");
        Console.WriteLine($"ID: {createdObject.Id}");

        return createdObject;
    }

    private async Task<Space> CreateSpaceAsync()
    {
        var name = "C# fandom";
        var description = "This is a space created using Anytype.NET.";

        var request = new CreateSpaceRequest()
        {
            Name = name,
            Description = description
        };

        var newSpace = await _client.Spaces.CreateAsync(request);

        Console.WriteLine("New space created:");
        Console.WriteLine(newSpace.Name);
        Console.WriteLine($"Description: {newSpace.Description}");
        Console.WriteLine($"ID: {newSpace.Id}");

        return newSpace;
    }

    private async Task GetSpacesAsync()
    {
        var offset = 0;
        var limit = 10;
        var hasMore = true;

        while (hasMore)
        {
            var response = await _client.Spaces.ListAsync(offset, limit);

            Console.WriteLine($"Retrieved {response.Spaces.Count} spaces out of total {response.Pagination.Total} (offset {offset}).");

            foreach (var space in response.Spaces)
            {
                Console.WriteLine($"- {space.Name} (ID: {space.Id})");
            }

            Console.WriteLine();

            hasMore = response.Pagination.HasMore;

            if (hasMore)
            {
                Console.WriteLine("More spaces are available. Do you want to load more? (y/n): ");

                var keyInfo = Console.ReadKey(intercept: true);
                var keyChar = char.ToLower(keyInfo.KeyChar);

                if (keyChar == 'y')
                {
                    offset += limit;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping further loading of spaces.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("All available spaces have been loaded.");
            }
        }
    }
}
