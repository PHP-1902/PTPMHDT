
namespace EduHub.Ch01.Domain;

/// <summary>
/// Represents a student who participates in EduHub clubs and events.
/// </summary>
public class Member
{
    private bool _isActive;

    /// <summary>
    /// Gets the unique identifier of the member.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the full name of the member.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the email address of the member.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets the student code of the member.
    /// </summary>
    public string StudentCode { get; private set; }

    /// <summary>
    /// Gets the date and time when the member joined.
    /// </summary>
    public DateTime JoinedAt { get; private set; }

    private Member(
        Guid id,
        string name,
        string email,
        string studentCode,
        DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
        _isActive = true;
    }

    /// <summary>
    /// Creates a member after validating the supplied information.
    /// </summary>
    public static Member Create(
        string name,
        string email,
        string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(email)
            || !email.Contains('@'))
            throw new ArgumentException(
                "A valid email is required.", nameof(email));

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException(
                "Student code cannot be empty.",
                nameof(studentCode));

        return new Member(
            Guid.NewGuid(),
            name.Trim(),
            email.Trim(),
            studentCode.Trim(),
            DateTime.UtcNow);
    }

    /// <summary>
    /// Returns whether the member is active.
    /// </summary>
    public bool IsActive()
    {
        return _isActive;
    }

    /// <summary>
    /// Deactivates the member.
    /// </summary>
    public void Deactivate()
    {
        _isActive = false;
    }
}
