namespace Domain.Auth;

public sealed class Role
{
    private Role() { }

    public Role(
        Guid id,
        string name)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));

        Id = id;
        SetName(name);
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        Name = name.Trim().ToLowerInvariant(); 
    }
}
