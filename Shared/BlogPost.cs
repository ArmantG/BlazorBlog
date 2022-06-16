namespace BlazorBlog.Shared;

public class BlogPost
{
  
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Title { get; init; }

    public string? Content { get; set; }

    public string? Author { get; set; }

    public string? Description { get; init; }

    public string? ImageUrl { get; set; }

    public DateTime DateCreated { get; set; }

    public bool IsPublished { get; set; }

    public bool IsDeleted { get; set; }
    
    public string? Comment { get; set; }
}