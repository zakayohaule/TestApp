using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Database;
using TestApp.Domains;
using TestApp.Services.Interfaces;

namespace TestApp.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> CreateAsync(Post postToAdd)
        {
            var newPost = await _dbContext.Posts.AddAsync(postToAdd);
            _dbContext.SaveChanges();

            return newPost.Entity;
        }

        public async Task<Post> FindByIdAsync(int Id)
        {
            return await _dbContext.Posts.SingleOrDefaultAsync(post => post.Id == Id);
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            _dbContext.Posts.Update(post);
            var updated = _dbContext.SaveChanges();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var postToDelete = await FindByIdAsync(id);

            _dbContext.Posts.Remove(postToDelete);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}