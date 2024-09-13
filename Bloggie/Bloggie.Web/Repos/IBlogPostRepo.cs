using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repos;

public interface IBlogPostRepo
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost?> GetAsync(Guid id);
    Task<BlogPost> AddAsync(BlogPost blogPost);
    Task<BlogPost> UpdateAsync(BlogPost blogPost);
    Task<bool> DeleteAsync(Guid id);
}
