using System.Text;

namespace Admin;
using Post;
using Notify;

class Admin
{
    public Guid id;
    public string? name, password;
    public uint age;
    public List<Post>? post;
    public List<Notify>? notify;

    public Admin(string? name, string? password, uint age, List<Post>? post = default, List<Notify>? notify = default)
    {
        id = Guid.NewGuid();
        this.name = name;
        this.password = password;
        this.age = age;
        this.post = post;
        this.notify = notify;
    }

    public Post CreatePosts()
    {
        string? content; 
        Console.WriteLine("Enter content of Post : ");
        content = Console.ReadLine();


        Post post = new(content);

        return post;
    }
}