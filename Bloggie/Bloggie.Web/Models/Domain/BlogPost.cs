namespace Bloggie.Web.Models.Domain;

public class BlogPost
{
    public Guid Id { get; set; }
    public string Heading { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set;}
    public bool Visible { get; set; }

    public void Map(BlogPost blogPostDb)
    {
        Heading = blogPostDb.Heading;
        PageTitle = blogPostDb.PageTitle;
        Content = blogPostDb.Content;
        ShortDescription = blogPostDb.ShortDescription;
        FeaturedImageUrl = blogPostDb.FeaturedImageUrl;
        UrlHandle = blogPostDb.UrlHandle;
        PublishedDate = blogPostDb.PublishedDate;
        Author = blogPostDb.Author;
        Visible = blogPostDb.Visible;
    }
}
