using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class ListModel : PageModel
{
    public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

    private readonly IBlogPostRepo _blogPostRepo;

    public ListModel(IBlogPostRepo blogPostRepo)
    {
        _blogPostRepo = blogPostRepo;
    }

    public async Task OnGet()
    {
        BlogPosts = (await _blogPostRepo.GetAllAsync()).ToList();
    }
}
