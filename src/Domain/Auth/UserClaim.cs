namespace Domain.Auth;

public sealed class UserClaim
{
    private UserClaim() { }
    public UserClaim(
        Guid userId,
        string type,
        string value)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        UserId = userId;
        SetType(type);
        SetValue(value);
    }

    public Guid UserId { get; private set; }
    public string Type { get; private set; } = null!;
    public string Value { get; private set; } = null!;

    private void SetType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("Type cannot be empty.", nameof(type));
        Type = type.Trim().ToLowerInvariant();
    }

    private void SetValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be empty.", nameof(value));
        Value = value.Trim().ToLowerInvariant();
    }
}
