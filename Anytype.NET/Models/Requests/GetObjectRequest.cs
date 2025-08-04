namespace Anytype.NET.Models.Requests;

public class GetObjectRequest
{
    /// <summary>
    /// Represents the data required to retrieve an object from a space.
    /// </summary>
    /// <param name="spaceId">The identifier of the space. Cannot be null, empty, or whitespace.</param>
    /// <param name="objectId">The identifier of the object. Cannot be null, empty, or whitespace.</param>
    /// <exception cref="ArgumentException"/>
    public GetObjectRequest(string spaceId, string objectId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null, empty, or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(objectId))
        {
            throw new ArgumentException("Object ID cannot be null, empty, or whitespace.", nameof(objectId));
        }

        SpaceId = spaceId;
        ObjectId = objectId;
    }

    /// <summary>
    /// Gets the space identifier.
    /// </summary>
    public string SpaceId { get; }

    /// <summary>
    /// Gets the object identifier.
    /// </summary>
    public string ObjectId { get; }
}
