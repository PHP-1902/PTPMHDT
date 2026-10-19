```csharp
#nullable enable

namespace EduHub.Ch01.Domain;

/// <summary>
/// Represents a club that organizes activities and events for members.
/// </summary>
public class Club
{
    /// <summary>
    /// Gets the unique identifier of the club.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the name of the club.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of the club.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the date and time when the club was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the members belonging to this club.
    /// </summary>
    public List<Member> Members { get; private set; }

    private Club(
        Guid id,
        string name,
        string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Members = new List<Member>();
    }

    /// <summary>
    /// Creates a club after validating the supplied information.
    /// </summary>
    /// <param name="name">The name of the club.</param>
    /// <param name="description">The description of the club.</param>
    /// <returns>A newly created club.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the club name or description is empty.
    /// </exception>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Club name cannot be empty.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException(
                "Club description cannot be empty.",
                nameof(description));
        }

        return new Club(
            Guid.NewGuid(),
            name.Trim(),
            description.Trim(),
            DateTime.UtcNow);
    }

    /// <summary>
    /// Adds a member to the club if the member is not already included.
    /// </summary>
    /// <param name="member">The member to add.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the member is null.
    /// </exception>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);

        if (Members.Exists(existing => existing.Id == member.Id))
        {
            return;
        }

        Members.Add(member);
    }

    /// <summary>
    /// Gets the total number of members in the club.
    /// </summary>
    /// <returns>The number of members.</returns>
    public int MemberCount()
    {
        return Members.Count;
    }
}
```
