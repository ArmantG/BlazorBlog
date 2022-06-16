using BlazorBlog.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
   
    //
    // public List<BlogPost> Posts { get; set; } = new()
    // {
    //     new BlogPost
    //     {
    //         Id = 1,
    //         Url = "first-post",
    //         Title = "First Post wills ok",
    //         Description = "Test 1",
    //         ImageUrl = "first-post.jpg",
    //         Content =
    //             "There is no strife, no prejudice, no national conflict in outer space as yet. Its hazards are hostile to us all. Its conquest deserves the best of all mankind, and its opportunity for peaceful cooperation many never come again. But why, some say, the moon? Why choose this as our goal? And they may well ask why climb the highest mountain? Why, 35 years ago, fly the Atlantic? Why does Rice play Texas? We choose to go to the moon. We choose to go to the moon in this decade and do the other things, not because they are easy, but because they are hard, because that goal will serve to organize and measure the best of our energies and skills, because that challenge is one that we are willing to accept, one we are unwilling to postpone, and one which we intend to win, and the others, too. It is for these reasons that I regard the decision last year to shift our efforts in space from low to high gear as among the most important decisions that will be made during my incumbency in the office of the Presidency.In the last 24 hours we have seen facilities now being created for the greatest and most complex exploration in man's history. We have felt the ground shake and the air shattered by the testing of a Saturn C-1 booster rocket, many times as powerful as the Atlas which launched John Glenn, generating power equivalent to 10,000 automobiles with their accelerators on the floor. We have seen the site where the F-1 rocket engines, each one as powerful as all eight engines of the Saturn combined, will be clustered together to make the advanced Saturn missile, assembled in a new building to be built at Cape Canaveral as tall as a 48 story structure, as wide as a city block, and as long as two lengths of this field.",
    //         Author = "John Doe",
    //         DateCreated = DateTime.Now,
    //         IsPublished = false,
    //         IsDeleted = false,
    //         Comment = "none"
    //     },
    //     new BlogPost
    //     {
    //         Id = 2,
    //         Url = "second-post",
    //         Title = "Second Post",
    //         Description = "Test 2",
    //         ImageUrl = "second-post.jpg",
    //         Content = "You think water moves fast? You should see ice. It moves like it has a mind. Like it knows it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. Nature is lethal but it doesn't hold a candle to man.",
    //         Author = "John Doer",
    //         DateCreated = DateTime.Now,
    //         IsPublished = false,
    //         IsDeleted = false,
    //         Comment = "none"
    //     }
    // };

    private readonly ApplicationDbContext _context;
    
    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    [HttpGet]
    public ActionResult<List<BlogPost>> GetAllBlogPosts()
    {
        return Ok(_context.BlogPosts);
    }

    [HttpGet("{url}")]
    public ActionResult<List<BlogPost>> GetSingleBlogPosts(string url)
    { 
        var post = _context.BlogPosts!.FirstOrDefault(p => p.Url != null && p.Url.ToLower().Equals(url.ToLower()));
        if (post == null)
        {
            return NotFound("No post found");
        }
       
        return Ok(post);
    }
}