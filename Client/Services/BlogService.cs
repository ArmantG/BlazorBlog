using System.Net.Http.Json;
using BlazorBlog.Shared;

namespace BlazorBlog.Client.Services;

public class BlogService : IBlogService
{
    private readonly HttpClient _http;

    public BlogService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<BlogPost>?> GetBlogPost()
    {
        return await _http.GetFromJsonAsync<List<BlogPost>>("api/Blog");
    }

    public async Task<BlogPost?> GetBlogPostByUrl(string? url)
    {
        // var post = await _http.GetFromJsonAsync<BlogPost>($"api/Blog/{url}");
        // return post;

        var result = await _http.GetAsync($"api/Blog/{url}");
        if (result.StatusCode != System.Net.HttpStatusCode.OK)
        {
           var message = await result.Content.ReadAsStreamAsync();
           Console.WriteLine(message);
           return new BlogPost { Title = message.ToString() };
        }
        
        
        return await result.Content.ReadFromJsonAsync<BlogPost>();

    }
}