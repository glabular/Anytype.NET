namespace Anytype.NET.Models;

public sealed class TemplateProperty
{
    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// The id of the property.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// The text value of the property.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The number value of the property.
    /// </summary>
    public double? Number { get; set; }

    /// <summary>
    /// The selected tag value of the property.
    /// </summary>
    public SelectValue Select { get; set; }

    /// <summary>
    /// The selected tag values of the property.
    /// </summary>
    public List<SelectValue> MultiSelect { get; set; }

    /// <summary>
    /// The date value of the property.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// The file values of the property.
    /// </summary>
    public List<string> Files { get; set; }

    /// <summary>
    /// The checkbox value of the property.
    /// </summary>
    public bool? Checkbox { get; set; }

    /// <summary>
    /// The URL value of the property.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The email value of the property.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The phone value of the property.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// The object values of the property.
    /// </summary>
    public List<string> Objects { get; set; }
}