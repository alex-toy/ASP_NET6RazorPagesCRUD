using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    [BindProperty]
    public BlogPost? BlogPost { get; set; }

    private readonly IBlogPostRepo _blogPostRepo;

    public EditModel(IBlogPostRepo blogPostRepo)
    {
        _blogPostRepo = blogPostRepo;
    }

    public async Task OnGet(Guid id)
    {
        BlogPost = await _blogPostRepo.GetAsync(id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        if (BlogPost is null) return RedirectToPage("/admin/blogs/list");

        await _blogPostRepo.UpdateAsync(BlogPost);

        return RedirectToPage("/admin/blogs/list");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        if (BlogPost is null) return RedirectToPage("/admin/blogs/list");

        bool result = await _blogPostRepo.DeleteAsync(BlogPost.Id);

        if (result == false) return Page();

        return RedirectToPage("/admin/blogs/list");
    }
}
