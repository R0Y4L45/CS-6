
namespace User;

internal class User
{
    public Guid id;
    public string? name, password;
    public uint age;

    public User(string? name, string? password, uint age)
    {
        id = Guid.NewGuid();
        this.name = name;
        this.password = password;
        this.age = age;

    }
}

