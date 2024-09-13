using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bloggie.Web.Repos;

public class BlogPostRepo : IBlogPostRepo
{
    private readonly DatabaseContext _databaseContext;

    public BlogPostRepo(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<BlogPost> AddAsync(BlogPost blogPost)
    {
        EntityEntry<BlogPost> entity = await _databaseContext.BlogPosts.AddAsync(blogPost);
        await _databaseContext.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        BlogPost? blogPostDb = await _databaseContext.BlogPosts.FindAsync(id);

        if (blogPostDb is null) return false;

        _databaseContext.BlogPosts.Remove(blogPostDb);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _databaseContext.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost?> GetAsync(Guid id)
    {
        return await _databaseContext.BlogPosts.FindAsync(id);
    }

    public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
    {
        BlogPost? blogPostDb = await _databaseContext.BlogPosts.FindAsync(blogPost.Id);

        if (blogPostDb is null) return null;

        blogPostDb.Map(blogPost);

        await _databaseContext.SaveChangesAsync();

        return blogPostDb;
    }
}
