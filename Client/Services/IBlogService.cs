using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services;

public interface IBlogService
{
    Task<List<BlogPost>?> GetBlogPost();

    Task<BlogPost?> GetBlogPostByUrl(string? url);
}