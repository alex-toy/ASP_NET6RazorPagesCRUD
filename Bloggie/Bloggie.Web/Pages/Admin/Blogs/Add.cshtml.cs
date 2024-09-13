using Bloggie.Web.Data;
using Bloggie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    [BindProperty]
    public AddBlogPost AddBlogPost { get; set; }

    private readonly DatabaseContext _databaseContext;

    public AddModel(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        _databaseContext.blogPosts.Add(AddBlogPost.ToBlogPost());
        _databaseContext.SaveChanges();

        return RedirectToPage("/admin/blogs/list");
    }
}
