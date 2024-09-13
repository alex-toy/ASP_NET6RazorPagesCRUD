using Bloggie.Web.Repos;
using Bloggie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    [BindProperty]
    public AddBlogPost AddBlogPost { get; set; }

    private readonly IBlogPostRepo _blogPostRepo;

    public AddModel(IBlogPostRepo blogPostRepo)
    {
        _blogPostRepo = blogPostRepo;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        _ = await _blogPostRepo.AddAsync(AddBlogPost.ToBlogPost());

        return RedirectToPage("/admin/blogs/list");
    }
}
