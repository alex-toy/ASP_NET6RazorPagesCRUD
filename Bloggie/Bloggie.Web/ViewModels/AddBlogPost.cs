using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.ViewModels;

public class AddBlogPost
{
    public string Heading { get; set; }

    public string PageTitle { get; set; }

    public string Content { get; set; }

    public string ShortDescription { get; set; }

    public string FeaturedImageUrl { get; set; }

    public string UrlHandle { get; set; }

    public DateTime PublishedDate { get; set; }

    public string Author { get; set; }

    public bool IsVisible { get; set; }

    public BlogPost ToBlogPost()
    {
        return new ()
        {
            Heading = Heading,
            PageTitle = PageTitle,
            Content = Content,
            ShortDescription = ShortDescription,
            FeaturedImageUrl = FeaturedImageUrl,
            UrlHandle = UrlHandle,
            PublishedDate = PublishedDate,
            Author = Author,
            Visible = IsVisible,
        };
    }
}
