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

    public void OnPost()
    {
        _databaseContext.blogPosts.Add(AddBlogPost.ToBlogPost());
        _databaseContext.SaveChanges();
    }

    // Bad way
    //public void OnPost()
    //{
    //    string heading = Request.Form["heading"];
    //    string pageTitle = Request.Form["pageTitle"];
    //    string content = Request.Form["content"];
    //    string shortDescription = Request.Form["shortDescription"];
    //    string featuredImagUrl = Request.Form["featuredImagUrl"];
    //    string urlHandle = Request.Form["urlHandle"];
    //    string publishedDate = Request.Form["publishedDate"];
    //    string author = Request.Form["author"];
    //    string isVisible = Request.Form["isVisible"];
    //}
}
