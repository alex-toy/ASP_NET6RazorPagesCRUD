using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    [BindProperty]
    public BlogPost? BlogPost { get; set; }

    private readonly DatabaseContext _databaseContext;

    public EditModel(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void OnGet(Guid id)
    {
        BlogPost = _databaseContext.blogPosts.Find(id);

        if (BlogPost is null) { return; }
    }

    public IActionResult OnPost()
    {
        if (BlogPost is null) return RedirectToPage("/admin/blogs/list");

        _databaseContext.blogPosts.Update(BlogPost);
        _databaseContext.SaveChanges();

        return RedirectToPage("/admin/blogs/list");
    }
}
