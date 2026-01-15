namespace Domain.Auth;

public sealed class User
{
    private User() { }

    public User(
        Guid id,
        string email,
        string passwordHash)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));

        Id = id;
        SetEmail(email);
        SetPasswordHash(passwordHash);
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private readonly List<UserRole> _roles = new();
    public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();

    private readonly List<UserClaim> _claims = new();
    public IReadOnlyCollection<UserClaim> Claims => _claims.AsReadOnly();

    public void Activate() { IsActive = true; }
    public void Deactivate() { IsActive = false; }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        Email = email.Trim().ToLowerInvariant();
    }

    public void SetPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));
        PasswordHash = passwordHash;
    }

    public void AddRole(Role role)
    {
        if (role == null) throw new ArgumentNullException(nameof(role));
        if (_roles.Any(r => r.RoleId == role.Id)) return;

        _roles.Add(new UserRole(Id, role.Id));
    }

    public void AddClaim(string type, string value)
    {
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("Claim type cannot be empty", nameof(type));
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Claim value cannot be empty", nameof(value));

        if (_claims.Any(c => c.Type == type && c.Value == value))
            return;

        _claims.Add(new UserClaim(Id, type, value));
    }
}

