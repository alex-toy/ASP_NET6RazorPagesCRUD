using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class ListModel : PageModel
{
    public List<BlogPost> BlogPosts { get; set; }

    private readonly DatabaseContext _databaseContext;

    public ListModel(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void OnGet()
    {
        BlogPosts = _databaseContext.blogPosts.ToList();
    }
}
