using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class ListModel : PageModel
{
    public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

    private readonly DatabaseContext _databaseContext;

    public ListModel(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task OnGet()
    {
        BlogPosts = await _databaseContext.BlogPosts.ToListAsync();
    }
}
