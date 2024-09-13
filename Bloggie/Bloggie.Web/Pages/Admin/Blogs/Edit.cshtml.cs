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

    public async Task OnGet(Guid id)
    {
        BlogPost = await _databaseContext.BlogPosts.FindAsync(id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        if (BlogPost is null) return RedirectToPage("/admin/blogs/list");

        BlogPost? blogPostDb = await _databaseContext.BlogPosts.FindAsync(BlogPost.Id);

        if (blogPostDb is null) return RedirectToPage("/admin/blogs/list");

        blogPostDb.Map(BlogPost);

        await _databaseContext.SaveChangesAsync();

        return RedirectToPage("/admin/blogs/list");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        if (BlogPost is null) return RedirectToPage("/admin/blogs/list");

        BlogPost? blogPostDb = await _databaseContext.BlogPosts.FindAsync(BlogPost.Id);

        if (blogPostDb is null) return Page();

        _databaseContext.BlogPosts.Remove(blogPostDb);
        await _databaseContext.SaveChangesAsync();

        return RedirectToPage("/admin/blogs/list");
    }
}
