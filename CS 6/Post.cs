
namespace Post;
internal class Post
{
    public Guid id;
    public String? content;
    public DateTime creationDateTime;
    public uint likeCount, viewCount;

    public Post(string? content, uint likeCount = 0, uint viewCount = 0)
    {
        id = Guid.NewGuid();
        this.content = content;
        creationDateTime = DateTime.Now;
        this.likeCount = likeCount;
        this.viewCount = viewCount;
    }

    public override string ToString()
    {
        return $@"ID -->  {id}
Content -->  {content}
Date -->  {creationDateTime}
Count of Like -->  {likeCount}
Count of Views -->  {viewCount}";
    }
}

